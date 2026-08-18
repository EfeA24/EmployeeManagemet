using Em.Core.Application.DTOs.CreateDtos.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Commands
{
    public class CreateNotificationCommand : IRequest<Guid>
    {
        public CreateNotificationDto CreateNotificationDto { get; set; } = null!;
    }
}
