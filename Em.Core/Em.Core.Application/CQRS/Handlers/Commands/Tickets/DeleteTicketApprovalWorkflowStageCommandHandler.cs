using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class DeleteTicketApprovalWorkflowStageCommandHandler : IRequestHandler<DeleteTicketApprovalWorkflowStageCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTicketApprovalWorkflowStageCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteTicketApprovalWorkflowStageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketApprovalWorkflowStageRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.TicketApprovalWorkflowStageRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
