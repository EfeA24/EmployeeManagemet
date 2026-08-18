using MediatR;

namespace Em.Core.Application.CQRS.Commands.Notifications
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
