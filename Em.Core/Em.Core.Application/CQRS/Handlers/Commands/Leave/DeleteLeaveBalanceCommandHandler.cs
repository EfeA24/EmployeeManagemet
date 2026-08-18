using MediatR;
using Em.Core.Application.CQRS.Commands.Leave;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Leave
{
    public class DeleteLeaveBalanceCommandHandler : IRequestHandler<DeleteLeaveBalanceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLeaveBalanceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteLeaveBalanceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.LeaveBalanceRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.LeaveBalanceRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
