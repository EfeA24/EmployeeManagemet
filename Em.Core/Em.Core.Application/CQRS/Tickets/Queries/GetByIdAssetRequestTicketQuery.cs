using Em.Core.Application.DTOs.ReadDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Queries
{
    public class GetByIdAssetRequestTicketQuery : IRequest<GetByIdAssetRequestTicketDto?>
    {
        public Guid Id { get; set; }

        public GetByIdAssetRequestTicketQuery(Guid id)
        {
            Id = id;
        }
    }
}
