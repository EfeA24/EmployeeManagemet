using Em.Core.Application.DTOs.ReadDtos.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Notifications
{
    public class GetByIdNotificationDeliveryQuery : IRequest<GetByIdNotificationDeliveryDto?>
    {
        public Guid Id { get; set; }

        public GetByIdNotificationDeliveryQuery(Guid id)
        {
            Id = id;
        }
    }
}
