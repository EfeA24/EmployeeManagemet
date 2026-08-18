using Em.Core.Application.DTOs.ReadDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Tickets
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
