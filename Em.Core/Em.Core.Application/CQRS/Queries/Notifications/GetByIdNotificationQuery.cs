using Em.Core.Application.DTOs.ReadDtos.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Notifications
{
    public class GetByIdNotificationQuery : IRequest<GetByIdNotificationDto?>
    {
        public Guid Id { get; set; }

        public GetByIdNotificationQuery(Guid id)
        {
            Id = id;
        }
    }
}
