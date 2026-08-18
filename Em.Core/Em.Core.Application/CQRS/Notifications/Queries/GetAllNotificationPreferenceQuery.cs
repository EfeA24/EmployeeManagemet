using Em.Core.Application.DTOs.ReadDtos.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Queries
{
    public class GetAllNotificationPreferenceQuery : IRequest<IReadOnlyList<GetAllNotificationPreferenceDto>>
    {
    }
}
