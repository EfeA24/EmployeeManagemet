using Em.Core.Application.DTOs.ReadDtos.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Queries
{
    public class GetAllDeviceTokenQuery : IRequest<IReadOnlyList<GetAllDeviceTokenDto>>
    {
    }
}
