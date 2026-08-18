using MediatR;
using Em.Core.Application.CQRS.Commands.Attendance;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Attendance
{
    public class DeleteAttendancePunchCommandHandler : IRequestHandler<DeleteAttendancePunchCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAttendancePunchCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteAttendancePunchCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AttendancePunchRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.AttendancePunchRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
