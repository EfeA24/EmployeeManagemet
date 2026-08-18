using Em.Core.Application.DTOs.ReadDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Tickets
{
    public class GetByIdGeneralTicketQuery : IRequest<GetByIdGeneralTicketDto?>
    {
        public Guid Id { get; set; }

        public GetByIdGeneralTicketQuery(Guid id)
        {
            Id = id;
        }
    }
}
