using Em.Core.Application.DTOs.ReadDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Queries
{
    public class GetAllSubscriptionPeriodQuery : IRequest<IReadOnlyList<GetAllSubscriptionPeriodDto>>
    {
    }
}
