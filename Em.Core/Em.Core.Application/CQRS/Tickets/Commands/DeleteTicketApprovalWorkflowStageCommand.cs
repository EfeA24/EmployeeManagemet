using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class DeleteTicketApprovalWorkflowStageCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteTicketApprovalWorkflowStageCommand(Guid id)
        {
            Id = id;
        }
    }
}
