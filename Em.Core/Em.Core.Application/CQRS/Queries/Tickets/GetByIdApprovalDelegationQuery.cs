using Em.Core.Application.DTOs.ReadDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Tickets
{
    public class GetByIdApprovalDelegationQuery : IRequest<GetByIdApprovalDelegationDto?>
    {
        public Guid Id { get; set; }

        public GetByIdApprovalDelegationQuery(Guid id)
        {
            Id = id;
        }
    }
}
