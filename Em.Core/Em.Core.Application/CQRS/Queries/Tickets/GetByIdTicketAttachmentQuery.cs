using Em.Core.Application.DTOs.ReadDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Tickets
{
    public class GetByIdTicketAttachmentQuery : IRequest<GetByIdTicketAttachmentDto?>
    {
        public Guid Id { get; set; }

        public GetByIdTicketAttachmentQuery(Guid id)
        {
            Id = id;
        }
    }
}
