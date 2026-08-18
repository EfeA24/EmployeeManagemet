using Em.Core.Application.DTOs.ReadDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Queries
{
    public class GetAllTicketApprovalWorkflowQuery : IRequest<IReadOnlyList<GetAllTicketApprovalWorkflowDto>>
    {
    }
}
