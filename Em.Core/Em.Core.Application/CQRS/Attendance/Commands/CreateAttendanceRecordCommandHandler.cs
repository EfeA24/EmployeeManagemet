using Em.Core.Application.CQRS.Attendance.Commands;
using Em.Core.Application.DTOs.CreateDtos.Attendance;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Commands
{
    public class CreateAttendanceRecordCommandHandler : IRequestHandler<CreateAttendanceRecordCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateAttendanceRecordCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateAttendanceRecordCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateAttendanceRecordDto, AttendanceRecord>(request.CreateAttendanceRecordDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AttendanceRecordRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<AttendanceRecord, GetByIdAttendanceRecordDto>(entity);
            await _cache.SetAsync($"AttendanceRecord:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
