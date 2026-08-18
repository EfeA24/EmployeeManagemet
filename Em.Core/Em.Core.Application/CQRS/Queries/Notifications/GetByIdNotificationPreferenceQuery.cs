using Em.Core.Application.DTOs.ReadDtos.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Notifications
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
