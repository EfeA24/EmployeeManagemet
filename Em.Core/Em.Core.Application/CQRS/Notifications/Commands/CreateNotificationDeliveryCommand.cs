using Em.Core.Application.DTOs.CreateDtos.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Commands
{
    public class CreateNotificationDeliveryCommand : IRequest<Guid>
    {
        public CreateNotificationDeliveryDto CreateNotificationDeliveryDto { get; set; } = null!;
    }
}
