using Em.Core.Application.DTOs.CreateDtos.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Notifications
{
    public class CreateNotificationPreferenceCommand : IRequest<Guid>
    {
        public CreateNotificationPreferenceDto CreateNotificationPreferenceDto { get; set; } = null!;
    }
}
