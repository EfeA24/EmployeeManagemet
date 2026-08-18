using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class DeleteTicketAttachmentCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteTicketAttachmentCommand(Guid id)
        {
            Id = id;
        }
    }
}
