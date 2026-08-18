using Em.Core.Application.CQRS.Attendance.Commands;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Commands
{
    public class UpdateAttendanceViolationCommandHandler : IRequestHandler<UpdateAttendanceViolationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateAttendanceViolationCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateAttendanceViolationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AttendanceViolationRepository.GetByIdAsync(request.UpdateAttendanceViolationDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateAttendanceViolationDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AttendanceViolationRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<AttendanceViolation, GetByIdAttendanceViolationDto>(entity);
            await _cache.SetAsync($"AttendanceViolation:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
