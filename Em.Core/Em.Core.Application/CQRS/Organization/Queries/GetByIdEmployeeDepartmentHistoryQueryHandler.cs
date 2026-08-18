using Em.Core.Application.CQRS.Organization.Queries;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Queries
{
    public class GetByIdEmployeeDepartmentHistoryQueryHandler : IRequestHandler<GetByIdEmployeeDepartmentHistoryQuery, GetByIdEmployeeDepartmentHistoryDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdEmployeeDepartmentHistoryQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdEmployeeDepartmentHistoryDto?> Handle(GetByIdEmployeeDepartmentHistoryQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<EmployeeDepartmentHistory>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<EmployeeDepartmentHistory, GetByIdEmployeeDepartmentHistoryDto>(entity);
        }
    }
}
