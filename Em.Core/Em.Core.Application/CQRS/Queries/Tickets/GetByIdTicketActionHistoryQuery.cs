using Em.Core.Application.DTOs.ReadDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Tickets
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
