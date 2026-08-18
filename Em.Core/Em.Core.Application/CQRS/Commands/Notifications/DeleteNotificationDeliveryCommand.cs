using MediatR;

namespace Em.Core.Application.CQRS.Commands.Notifications
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
