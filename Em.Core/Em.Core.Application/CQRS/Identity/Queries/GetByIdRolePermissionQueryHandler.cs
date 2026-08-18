using Em.Core.Application.CQRS.Identity.Queries;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Queries
{
    public class GetByIdRolePermissionQueryHandler : IRequestHandler<GetByIdRolePermissionQuery, GetByIdRolePermissionDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdRolePermissionQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdRolePermissionDto?> Handle(GetByIdRolePermissionQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<RolePermission>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<RolePermission, GetByIdRolePermissionDto>(entity);
        }
    }
}
