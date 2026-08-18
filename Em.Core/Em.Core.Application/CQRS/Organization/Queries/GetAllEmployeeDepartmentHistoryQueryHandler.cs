using Em.Core.Application.CQRS.Organization.Queries;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Queries
{
    public class GetAllEmployeeDepartmentHistoryQueryHandler : IRequestHandler<GetAllEmployeeDepartmentHistoryQuery, IReadOnlyList<GetAllEmployeeDepartmentHistoryDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllEmployeeDepartmentHistoryQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllEmployeeDepartmentHistoryDto>> Handle(GetAllEmployeeDepartmentHistoryQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<EmployeeDepartmentHistory>(cancellationToken);

            return entities
                .Select(DtoMapper.Map<EmployeeDepartmentHistory, GetAllEmployeeDepartmentHistoryDto>)
                .ToList();
        }
    }
}
