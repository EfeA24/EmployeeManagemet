using Em.Core.Application.CQRS.Identity.Queries;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Queries
{
    public class GetByIdPermissionQueryHandler : IRequestHandler<GetByIdPermissionQuery, GetByIdPermissionDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdPermissionQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdPermissionDto?> Handle(GetByIdPermissionQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<Permission>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<Permission, GetByIdPermissionDto>(entity);
        }
    }
}
