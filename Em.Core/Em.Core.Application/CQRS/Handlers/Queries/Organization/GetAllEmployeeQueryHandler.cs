using Em.Core.Application.CQRS.Queries.Organization;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Organization
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, IReadOnlyList<GetAllEmployeeDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllEmployeeQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllEmployeeDto>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<Employee>(cancellationToken);

            return entities
                .Select(x => x.ToGetAllDto())
                .ToList();
        }
    }
}
