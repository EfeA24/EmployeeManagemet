using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
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
