using Em.Core.Application.DTOs.CreateDtos.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Commands
{
    public class CreateDeviceTokenCommand : IRequest<Guid>
    {
        public CreateDeviceTokenDto CreateDeviceTokenDto { get; set; } = null!;
    }
}
