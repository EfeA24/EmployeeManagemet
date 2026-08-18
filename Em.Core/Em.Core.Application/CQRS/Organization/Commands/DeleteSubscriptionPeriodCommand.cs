using MediatR;

namespace Em.Core.Application.CQRS.Organization.Commands
{
    public class DeleteSubscriptionPeriodCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteSubscriptionPeriodCommand(Guid id)
        {
            Id = id;
        }
    }
}
