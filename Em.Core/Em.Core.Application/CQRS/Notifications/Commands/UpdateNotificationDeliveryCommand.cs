using Em.Core.Application.DTOs.UpdateDtos.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Commands
{
    public class UpdateNotificationDeliveryCommand : IRequest
    {
        public UpdateNotificationDeliveryDto UpdateNotificationDeliveryDto { get; set; } = null!;
    }
}
