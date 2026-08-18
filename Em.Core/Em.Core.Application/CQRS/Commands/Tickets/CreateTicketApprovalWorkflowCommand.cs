using Em.Core.Application.DTOs.CreateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
{
    public class CreateTicketApprovalWorkflowCommand : IRequest<Guid>
    {
        public CreateTicketApprovalWorkflowDto CreateTicketApprovalWorkflowDto { get; set; } = null!;
    }
}
