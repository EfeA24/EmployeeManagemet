using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Commands
{
    public class DeleteNotificationCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteNotificationCommand(Guid id)
        {
            Id = id;
        }
    }
}
