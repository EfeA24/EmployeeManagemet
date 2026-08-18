using Em.Core.Application.DTOs.UpdateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class UpdateTicketApprovalWorkflowStageCommand : IRequest
    {
        public UpdateTicketApprovalWorkflowStageDto UpdateTicketApprovalWorkflowStageDto { get; set; } = null!;
    }
}
