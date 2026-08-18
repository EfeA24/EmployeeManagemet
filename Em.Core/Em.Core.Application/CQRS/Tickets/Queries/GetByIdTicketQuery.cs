using Em.Core.Application.DTOs.ReadDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Queries
{
    public class GetByIdTicketQuery : IRequest<GetByIdTicketDto?>
    {
        public Guid Id { get; set; }

        public GetByIdTicketQuery(Guid id)
        {
            Id = id;
        }
    }
}
