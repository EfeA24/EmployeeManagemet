using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class DeleteLeaveTicketCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteLeaveTicketCommand(Guid id)
        {
            Id = id;
        }
    }
}
