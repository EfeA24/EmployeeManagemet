using MediatR;

namespace Em.Core.Application.CQRS.Commands.Notifications
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
