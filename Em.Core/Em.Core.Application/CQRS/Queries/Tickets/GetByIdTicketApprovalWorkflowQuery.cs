using Em.Core.Application.DTOs.ReadDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Tickets
{
    public class GetByIdTicketApprovalWorkflowQuery : IRequest<GetByIdTicketApprovalWorkflowDto?>
    {
        public Guid Id { get; set; }

        public GetByIdTicketApprovalWorkflowQuery(Guid id)
        {
            Id = id;
        }
    }
}
