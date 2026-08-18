using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
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
