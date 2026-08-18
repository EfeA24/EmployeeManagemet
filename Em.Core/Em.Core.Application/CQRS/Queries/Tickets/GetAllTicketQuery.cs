using Em.Core.Application.DTOs.ReadDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Tickets
{
    public class GetAllTicketQuery : IRequest<IReadOnlyList<GetAllTicketDto>>
    {
    }
}
