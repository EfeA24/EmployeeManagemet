using Em.Core.Application.CQRS.Queries.Assets;
using Em.Core.Application.DTOs.ReadDtos.Assets;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Assets;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Assets
{
    public class GetAllAssetAssignmentQueryHandler : IRequestHandler<GetAllAssetAssignmentQuery, IReadOnlyList<GetAllAssetAssignmentDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllAssetAssignmentQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllAssetAssignmentDto>> Handle(GetAllAssetAssignmentQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<AssetAssignment>(cancellationToken);

            return entities
                .Select(x => x.ToGetAllDto())
                .ToList();
        }
    }
}
