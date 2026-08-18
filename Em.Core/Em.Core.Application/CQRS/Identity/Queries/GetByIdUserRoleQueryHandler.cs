using Em.Core.Application.CQRS.Identity.Queries;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Queries
{
    public class GetByIdUserRoleQueryHandler : IRequestHandler<GetByIdUserRoleQuery, GetByIdUserRoleDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdUserRoleQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdUserRoleDto?> Handle(GetByIdUserRoleQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<UserRole>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<UserRole, GetByIdUserRoleDto>(entity);
        }
    }
}
