using Em.Core.Application.DTOs.UpdateDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Commands
{
    public class UpdateSubscriptionPeriodCommand : IRequest
    {
        public UpdateSubscriptionPeriodDto UpdateSubscriptionPeriodDto { get; set; } = null!;
    }
}
