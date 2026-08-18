using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Commands
{
    public class DeleteNotificationPreferenceCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteNotificationPreferenceCommand(Guid id)
        {
            Id = id;
        }
    }
}
