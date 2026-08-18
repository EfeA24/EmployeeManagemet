using Em.Core.Application.DTOs.ReadDtos.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Notifications
{
    public class GetAllNotificationPreferenceQuery : IRequest<IReadOnlyList<GetAllNotificationPreferenceDto>>
    {
    }
}
