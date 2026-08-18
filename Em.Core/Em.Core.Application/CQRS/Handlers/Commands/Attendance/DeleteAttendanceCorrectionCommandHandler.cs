using MediatR;
using Em.Core.Application.CQRS.Commands.Attendance;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Attendance
{
    public class DeleteAttendanceCorrectionCommandHandler : IRequestHandler<DeleteAttendanceCorrectionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAttendanceCorrectionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteAttendanceCorrectionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AttendanceCorrectionRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.AttendanceCorrectionRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
