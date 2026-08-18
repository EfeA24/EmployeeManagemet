using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Commands
{
    public class DeleteNotificationDeliveryCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteNotificationDeliveryCommand(Guid id)
        {
            Id = id;
        }
    }
}
