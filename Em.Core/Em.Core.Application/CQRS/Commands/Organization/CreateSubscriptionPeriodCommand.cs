using Em.Core.Application.DTOs.CreateDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Organization
{
    public class CreateSubscriptionPeriodCommand : IRequest<Guid>
    {
        public CreateSubscriptionPeriodDto CreateSubscriptionPeriodDto { get; set; } = null!;
    }
}
