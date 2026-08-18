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
    public class CreateAttendancePunchCommandHandler : IRequestHandler<CreateAttendancePunchCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateAttendancePunchCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateAttendancePunchCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateAttendancePunchDto, AttendancePunch>(request.CreateAttendancePunchDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AttendancePunchRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<AttendancePunch, GetByIdAttendancePunchDto>(entity);
            await _cache.SetAsync($"AttendancePunch:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
