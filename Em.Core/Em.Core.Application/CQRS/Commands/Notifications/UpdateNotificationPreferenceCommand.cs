using Em.Core.Application.DTOs.UpdateDtos.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Notifications
{
    public class UpdateNotificationPreferenceCommand : IRequest
    {
        public UpdateNotificationPreferenceDto UpdateNotificationPreferenceDto { get; set; } = null!;
    }
}
