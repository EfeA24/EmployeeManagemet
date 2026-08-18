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
    public class CreateAttendanceViolationCommandHandler : IRequestHandler<CreateAttendanceViolationCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateAttendanceViolationCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateAttendanceViolationCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateAttendanceViolationDto, AttendanceViolation>(request.CreateAttendanceViolationDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AttendanceViolationRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<AttendanceViolation, GetByIdAttendanceViolationDto>(entity);
            await _cache.SetAsync($"AttendanceViolation:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
