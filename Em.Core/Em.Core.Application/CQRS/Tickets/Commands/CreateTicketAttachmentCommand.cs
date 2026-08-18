using Em.Core.Application.DTOs.CreateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class CreateTicketAttachmentCommand : IRequest<Guid>
    {
        public CreateTicketAttachmentDto CreateTicketAttachmentDto { get; set; } = null!;
    }
}
