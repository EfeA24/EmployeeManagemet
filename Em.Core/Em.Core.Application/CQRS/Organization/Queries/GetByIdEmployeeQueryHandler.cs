using Em.Core.Application.CQRS.Organization.Queries;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Queries
{
    public class GetByIdEmployeeQueryHandler : IRequestHandler<GetByIdEmployeeQuery, GetByIdEmployeeDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdEmployeeQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdEmployeeDto?> Handle(GetByIdEmployeeQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<Employee>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<Employee, GetByIdEmployeeDto>(entity);
        }
    }
}
