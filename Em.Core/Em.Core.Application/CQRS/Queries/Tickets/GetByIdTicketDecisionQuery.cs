using Em.Core.Application.DTOs.ReadDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Tickets
{
    public class GetByIdTicketDecisionQuery : IRequest<GetByIdTicketDecisionDto?>
    {
        public Guid Id { get; set; }

        public GetByIdTicketDecisionQuery(Guid id)
        {
            Id = id;
        }
    }
}
