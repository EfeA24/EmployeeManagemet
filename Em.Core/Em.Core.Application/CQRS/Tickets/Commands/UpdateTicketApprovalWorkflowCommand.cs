using Em.Core.Application.DTOs.UpdateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class UpdateTicketApprovalWorkflowCommand : IRequest
    {
        public UpdateTicketApprovalWorkflowDto UpdateTicketApprovalWorkflowDto { get; set; } = null!;
    }
}
