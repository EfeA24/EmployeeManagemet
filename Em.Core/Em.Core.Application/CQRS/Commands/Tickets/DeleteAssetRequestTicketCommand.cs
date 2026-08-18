using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
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
