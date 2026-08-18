using Em.Core.Application.CQRS.Queries.Assets;
using Em.Core.Application.DTOs.ReadDtos.Assets;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Assets;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Assets
{
    public class GetAllAssetQueryHandler : IRequestHandler<GetAllAssetQuery, IReadOnlyList<GetAllAssetDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllAssetQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllAssetDto>> Handle(GetAllAssetQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<Asset>(cancellationToken);

            return entities
                .Select(x => x.ToGetAllDto())
                .ToList();
        }
    }
}
