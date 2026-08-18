using Em.Core.Application.DTOs.UpdateDtos.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Notifications
{
    public class UpdateDeviceTokenCommand : IRequest
    {
        public UpdateDeviceTokenDto UpdateDeviceTokenDto { get; set; } = null!;
    }
}
