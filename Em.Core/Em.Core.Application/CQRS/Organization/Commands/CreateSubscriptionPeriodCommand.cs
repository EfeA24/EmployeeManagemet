using Em.Core.Application.DTOs.CreateDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Commands
{
    public class CreateSubscriptionPeriodCommand : IRequest<Guid>
    {
        public CreateSubscriptionPeriodDto CreateSubscriptionPeriodDto { get; set; } = null!;
    }
}
