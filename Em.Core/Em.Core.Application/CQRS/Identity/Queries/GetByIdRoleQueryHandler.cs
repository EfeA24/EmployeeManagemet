using Em.Core.Application.CQRS.Identity.Queries;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Queries
{
    public class GetByIdRoleQueryHandler : IRequestHandler<GetByIdRoleQuery, GetByIdRoleDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdRoleQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdRoleDto?> Handle(GetByIdRoleQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<Role>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<Role, GetByIdRoleDto>(entity);
        }
    }
}
