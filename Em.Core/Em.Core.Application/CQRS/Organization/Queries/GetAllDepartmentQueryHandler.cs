using Em.Core.Application.CQRS.Organization.Queries;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Queries
{
    public class GetAllDepartmentQueryHandler : IRequestHandler<GetAllDepartmentQuery, IReadOnlyList<GetAllDepartmentDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllDepartmentQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllDepartmentDto>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<Department>(cancellationToken);

            return entities
                .Select(DtoMapper.Map<Department, GetAllDepartmentDto>)
                .ToList();
        }
    }
}
