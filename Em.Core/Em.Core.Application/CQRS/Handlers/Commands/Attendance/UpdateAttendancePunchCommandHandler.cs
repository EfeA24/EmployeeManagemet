using MediatR;
using Em.Core.Application.CQRS.Commands.Attendance;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Attendance;

namespace Em.Core.Application.CQRS.Handlers.Commands.Attendance
{
    public class UpdateAttendancePunchCommandHandler : IRequestHandler<UpdateAttendancePunchCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAttendancePunchCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateAttendancePunchCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AttendancePunchRepository.GetByIdAsync(request.UpdateAttendancePunchDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateAttendancePunchDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AttendancePunchRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
