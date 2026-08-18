using Em.Core.Application.CQRS.Identity.Queries;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Queries
{
    public class GetAllRolePermissionQueryHandler : IRequestHandler<GetAllRolePermissionQuery, IReadOnlyList<GetAllRolePermissionDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllRolePermissionQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllRolePermissionDto>> Handle(GetAllRolePermissionQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<RolePermission>(cancellationToken);

            return entities
                .Select(DtoMapper.Map<RolePermission, GetAllRolePermissionDto>)
                .ToList();
        }
    }
}
