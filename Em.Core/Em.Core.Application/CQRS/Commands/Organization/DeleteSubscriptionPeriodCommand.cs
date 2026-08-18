using MediatR;

namespace Em.Core.Application.CQRS.Commands.Organization
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
