using Em.Core.Application.DTOs.CreateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
{
    public class CreateTicketApprovalWorkflowStageCommand : IRequest<Guid>
    {
        public CreateTicketApprovalWorkflowStageDto CreateTicketApprovalWorkflowStageDto { get; set; } = null!;
    }
}
