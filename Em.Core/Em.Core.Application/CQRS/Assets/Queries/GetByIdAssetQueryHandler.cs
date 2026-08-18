using Em.Core.Application.CQRS.Assets.Queries;
using Em.Core.Application.DTOs.ReadDtos.Assets;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Assets;
using MediatR;

namespace Em.Core.Application.CQRS.Assets.Queries
{
    public class GetByIdAssetQueryHandler : IRequestHandler<GetByIdAssetQuery, GetByIdAssetDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdAssetQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdAssetDto?> Handle(GetByIdAssetQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<Asset>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<Asset, GetByIdAssetDto>(entity);
        }
    }
}
