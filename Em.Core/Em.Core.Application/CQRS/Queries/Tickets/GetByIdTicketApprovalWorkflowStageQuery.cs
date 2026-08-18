using Em.Core.Application.DTOs.ReadDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Tickets
{
    public class GetByIdTicketApprovalWorkflowStageQuery : IRequest<GetByIdTicketApprovalWorkflowStageDto?>
    {
        public Guid Id { get; set; }

        public GetByIdTicketApprovalWorkflowStageQuery(Guid id)
        {
            Id = id;
        }
    }
}
