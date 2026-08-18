using MediatR;
using Em.Core.Application.CQRS.Commands.Attendance;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Attendance;

namespace Em.Core.Application.CQRS.Handlers.Commands.Attendance
{
    public class UpdateAttendanceViolationCommandHandler : IRequestHandler<UpdateAttendanceViolationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAttendanceViolationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
}
}
}
