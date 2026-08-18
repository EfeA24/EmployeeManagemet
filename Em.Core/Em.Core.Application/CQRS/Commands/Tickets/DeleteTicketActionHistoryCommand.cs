using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
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
