using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class DeleteTicketCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteTicketCommand(Guid id)
        {
            Id = id;
        }
    }
}
