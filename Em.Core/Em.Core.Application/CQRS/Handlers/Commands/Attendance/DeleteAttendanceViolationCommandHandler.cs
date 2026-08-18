using MediatR;
using Em.Core.Application.CQRS.Commands.Attendance;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Attendance
{
    public class DeleteAttendanceViolationCommandHandler : IRequestHandler<DeleteAttendanceViolationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAttendanceViolationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteAttendanceViolationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AttendanceViolationRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.AttendanceViolationRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
