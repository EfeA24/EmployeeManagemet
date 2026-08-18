using Em.Core.Application.DTOs.CreateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
{
    public class CreateTicketAttachmentCommand : IRequest<Guid>
    {
        public CreateTicketAttachmentDto CreateTicketAttachmentDto { get; set; } = null!;
    }
}
