using Em.Core.Application.DTOs.UpdateDtos.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Notifications
{
    public class UpdateNotificationCommand : IRequest
    {
        public UpdateNotificationDto UpdateNotificationDto { get; set; } = null!;
    }
}
