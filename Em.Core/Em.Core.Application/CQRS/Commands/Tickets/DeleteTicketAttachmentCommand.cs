using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
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
