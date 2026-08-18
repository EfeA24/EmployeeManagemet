using Em.Core.Application.DTOs.ReadDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Tickets
{
    public class GetByIdTicketApprovalPermissionQuery : IRequest<GetByIdTicketApprovalPermissionDto?>
    {
        public Guid Id { get; set; }

        public GetByIdTicketApprovalPermissionQuery(Guid id)
        {
            Id = id;
        }
    }
}
