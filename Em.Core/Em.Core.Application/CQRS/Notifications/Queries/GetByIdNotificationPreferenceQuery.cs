using Em.Core.Application.DTOs.ReadDtos.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Queries
{
    public class GetByIdNotificationPreferenceQuery : IRequest<GetByIdNotificationPreferenceDto?>
    {
        public Guid Id { get; set; }

        public GetByIdNotificationPreferenceQuery(Guid id)
        {
            Id = id;
        }
    }
}
