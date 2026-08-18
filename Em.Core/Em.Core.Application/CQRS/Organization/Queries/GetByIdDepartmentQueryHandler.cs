using Em.Core.Application.CQRS.Organization.Queries;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Queries
{
    public class GetByIdDepartmentQueryHandler : IRequestHandler<GetByIdDepartmentQuery, GetByIdDepartmentDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdDepartmentQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdDepartmentDto?> Handle(GetByIdDepartmentQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<Department>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<Department, GetByIdDepartmentDto>(entity);
        }
    }
}
