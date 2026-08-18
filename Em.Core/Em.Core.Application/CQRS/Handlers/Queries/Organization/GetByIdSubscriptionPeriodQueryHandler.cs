using Em.Core.Application.CQRS.Queries.Organization;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Organization
{
    public class GetByIdSubscriptionPeriodQueryHandler : IRequestHandler<GetByIdSubscriptionPeriodQuery, GetByIdSubscriptionPeriodDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdSubscriptionPeriodQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdSubscriptionPeriodDto?> Handle(GetByIdSubscriptionPeriodQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<SubscriptionPeriod>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return entity.ToGetByIdDto();
        }
    }
}
