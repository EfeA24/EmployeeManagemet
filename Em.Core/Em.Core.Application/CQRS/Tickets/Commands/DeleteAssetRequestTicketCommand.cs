using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class DeleteAssetRequestTicketCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteAssetRequestTicketCommand(Guid id)
        {
            Id = id;
        }
    }
}
