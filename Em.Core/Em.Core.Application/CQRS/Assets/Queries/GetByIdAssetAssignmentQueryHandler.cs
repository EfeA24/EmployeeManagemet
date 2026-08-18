using Em.Core.Application.CQRS.Assets.Queries;
using Em.Core.Application.DTOs.ReadDtos.Assets;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Assets;
using MediatR;

namespace Em.Core.Application.CQRS.Assets.Queries
{
    public class GetByIdAssetAssignmentQueryHandler : IRequestHandler<GetByIdAssetAssignmentQuery, GetByIdAssetAssignmentDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdAssetAssignmentQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdAssetAssignmentDto?> Handle(GetByIdAssetAssignmentQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<AssetAssignment>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<AssetAssignment, GetByIdAssetAssignmentDto>(entity);
        }
    }
}
