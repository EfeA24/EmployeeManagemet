using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
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
