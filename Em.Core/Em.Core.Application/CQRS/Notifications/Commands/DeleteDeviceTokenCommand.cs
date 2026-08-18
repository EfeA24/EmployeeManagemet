using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Commands
{
    public class DeleteDeviceTokenCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteDeviceTokenCommand(Guid id)
        {
            Id = id;
        }
    }
}
