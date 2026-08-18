using Em.Core.Application.DTOs.UpdateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class UpdateTicketAttachmentCommand : IRequest
    {
        public UpdateTicketAttachmentDto UpdateTicketAttachmentDto { get; set; } = null!;
    }
}
