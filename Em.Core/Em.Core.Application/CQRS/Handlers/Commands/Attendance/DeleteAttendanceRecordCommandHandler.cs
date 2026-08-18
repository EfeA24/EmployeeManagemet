using MediatR;
using Em.Core.Application.CQRS.Commands.Attendance;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Attendance
{
    public class DeleteAttendanceRecordCommandHandler : IRequestHandler<DeleteAttendanceRecordCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAttendanceRecordCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteAttendanceRecordCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AttendanceRecordRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.AttendanceRecordRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
