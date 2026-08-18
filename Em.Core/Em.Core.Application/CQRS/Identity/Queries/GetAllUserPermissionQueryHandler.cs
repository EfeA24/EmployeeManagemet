using Em.Core.Application.CQRS.Identity.Queries;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Queries
{
    public class GetAllUserPermissionQueryHandler : IRequestHandler<GetAllUserPermissionQuery, IReadOnlyList<GetAllUserPermissionDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllUserPermissionQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllUserPermissionDto>> Handle(GetAllUserPermissionQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<UserPermission>(cancellationToken);

            return entities
                .Select(DtoMapper.Map<UserPermission, GetAllUserPermissionDto>)
                .ToList();
        }
    }
}
