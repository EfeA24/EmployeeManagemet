using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class DeleteTicketDecisionCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteTicketDecisionCommand(Guid id)
        {
            Id = id;
        }
    }
}
