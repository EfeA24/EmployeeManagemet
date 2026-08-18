using Em.Core.Application.DTOs.ReadDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Tickets
{
    public class GetAllTicketAttachmentQuery : IRequest<IReadOnlyList<GetAllTicketAttachmentDto>>
    {
    }
}
