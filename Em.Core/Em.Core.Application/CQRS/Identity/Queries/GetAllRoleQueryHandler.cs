using Em.Core.Application.CQRS.Identity.Queries;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Queries
{
    public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, IReadOnlyList<GetAllRoleDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllRoleQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllRoleDto>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<Role>(cancellationToken);

            return entities
                .Select(DtoMapper.Map<Role, GetAllRoleDto>)
                .ToList();
        }
    }
}
