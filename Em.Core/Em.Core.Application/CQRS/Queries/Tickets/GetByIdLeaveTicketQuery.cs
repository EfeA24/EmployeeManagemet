using Em.Core.Application.DTOs.ReadDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Tickets
{
    public class GetByIdLeaveTicketQuery : IRequest<GetByIdLeaveTicketDto?>
    {
        public Guid Id { get; set; }

        public GetByIdLeaveTicketQuery(Guid id)
        {
            Id = id;
        }
    }
}
