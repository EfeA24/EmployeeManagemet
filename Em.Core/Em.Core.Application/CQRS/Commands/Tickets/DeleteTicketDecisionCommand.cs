using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
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
