using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class DeleteTicketApprovalWorkflowCommandHandler : IRequestHandler<DeleteTicketApprovalWorkflowCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTicketApprovalWorkflowCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteTicketApprovalWorkflowCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketApprovalWorkflowRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.TicketApprovalWorkflowRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
