using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
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
