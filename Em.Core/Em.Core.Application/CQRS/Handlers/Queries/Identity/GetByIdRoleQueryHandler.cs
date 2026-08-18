using Em.Core.Application.CQRS.Queries.Identity;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Identity
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

            return entity.ToGetByIdDto();
        }
    }
}
