using Em.Core.Application.CQRS.Queries.Identity;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Identity
{
    public class GetAllUserRoleQueryHandler : IRequestHandler<GetAllUserRoleQuery, IReadOnlyList<GetAllUserRoleDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllUserRoleQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllUserRoleDto>> Handle(GetAllUserRoleQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<UserRole>(cancellationToken);

            return entities
                .Select(x => x.ToGetAllDto())
                .ToList();
        }
    }
}
