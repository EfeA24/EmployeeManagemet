using Em.Core.Application.DTOs.ReadDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Queries
{
    public class GetByIdTicketActionHistoryQuery : IRequest<GetByIdTicketActionHistoryDto?>
    {
        public Guid Id { get; set; }

        public GetByIdTicketActionHistoryQuery(Guid id)
        {
            Id = id;
        }
    }
}
