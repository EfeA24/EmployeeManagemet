using Em.Core.Application.DTOs.UpdateDtos.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Commands
{
    public class UpdateNotificationPreferenceCommand : IRequest
    {
        public UpdateNotificationPreferenceDto UpdateNotificationPreferenceDto { get; set; } = null!;
    }
}
