using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class DeleteTicketApprovalWorkflowCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteTicketApprovalWorkflowCommand(Guid id)
        {
            Id = id;
        }
    }
}
