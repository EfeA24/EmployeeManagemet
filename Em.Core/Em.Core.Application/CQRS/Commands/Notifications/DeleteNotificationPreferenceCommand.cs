using MediatR;

namespace Em.Core.Application.CQRS.Commands.Notifications
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
