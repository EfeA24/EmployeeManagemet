using MediatR;
using Em.Core.Application.CQRS.Commands.Attendance;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Attendance
{
    public class DeleteAttendancePolicyCommandHandler : IRequestHandler<DeleteAttendancePolicyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAttendancePolicyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteAttendancePolicyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AttendencePolicyRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.AttendencePolicyRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
