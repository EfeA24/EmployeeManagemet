using Em.Core.Application.DTOs.UpdateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
{
    public class UpdateTicketApprovalWorkflowCommand : IRequest
    {
        public UpdateTicketApprovalWorkflowDto UpdateTicketApprovalWorkflowDto { get; set; } = null!;
    }
}
