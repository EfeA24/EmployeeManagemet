using Em.Core.Application.DTOs.UpdateDtos.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Notifications
{
    public class UpdateNotificationDeliveryCommand : IRequest
    {
        public UpdateNotificationDeliveryDto UpdateNotificationDeliveryDto { get; set; } = null!;
    }
}
