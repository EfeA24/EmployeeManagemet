using Em.Core.Application.DTOs.UpdateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
{
    public class UpdateTicketApprovalWorkflowStageCommand : IRequest
    {
        public UpdateTicketApprovalWorkflowStageDto UpdateTicketApprovalWorkflowStageDto { get; set; } = null!;
    }
}
