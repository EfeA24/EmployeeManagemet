using Em.Core.Application.DTOs.ReadDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Queries
{
    public class GetByIdSubscriptionPeriodQuery : IRequest<GetByIdSubscriptionPeriodDto?>
    {
        public Guid Id { get; set; }

        public GetByIdSubscriptionPeriodQuery(Guid id)
        {
            Id = id;
        }
    }
}
