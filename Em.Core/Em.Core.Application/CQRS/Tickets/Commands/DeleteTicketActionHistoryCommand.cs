using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class DeleteTicketActionHistoryCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteTicketActionHistoryCommand(Guid id)
        {
            Id = id;
        }
    }
}
