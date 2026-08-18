using Em.Core.Application.CQRS.Organization.Queries;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Queries
{
    public class GetAllSubscriptionPeriodQueryHandler : IRequestHandler<GetAllSubscriptionPeriodQuery, IReadOnlyList<GetAllSubscriptionPeriodDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllSubscriptionPeriodQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllSubscriptionPeriodDto>> Handle(GetAllSubscriptionPeriodQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<SubscriptionPeriod>(cancellationToken);

            return entities
                .Select(DtoMapper.Map<SubscriptionPeriod, GetAllSubscriptionPeriodDto>)
                .ToList();
        }
    }
}
