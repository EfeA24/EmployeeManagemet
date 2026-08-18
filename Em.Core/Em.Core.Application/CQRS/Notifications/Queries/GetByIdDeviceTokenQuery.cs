using Em.Core.Application.DTOs.ReadDtos.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Queries
{
    public class GetByIdDeviceTokenQuery : IRequest<GetByIdDeviceTokenDto?>
    {
        public Guid Id { get; set; }

        public GetByIdDeviceTokenQuery(Guid id)
        {
            Id = id;
        }
    }
}
