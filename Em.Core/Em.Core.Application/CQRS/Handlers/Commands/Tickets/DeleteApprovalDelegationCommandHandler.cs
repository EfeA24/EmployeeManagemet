using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class DeleteApprovalDelegationCommandHandler : IRequestHandler<DeleteApprovalDelegationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteApprovalDelegationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteApprovalDelegationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ApprovalDelegationRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.ApprovalDelegationRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
