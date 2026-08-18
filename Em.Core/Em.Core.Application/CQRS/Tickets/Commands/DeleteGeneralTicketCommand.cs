using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class DeleteGeneralTicketCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteGeneralTicketCommand(Guid id)
        {
            Id = id;
        }
    }
}
