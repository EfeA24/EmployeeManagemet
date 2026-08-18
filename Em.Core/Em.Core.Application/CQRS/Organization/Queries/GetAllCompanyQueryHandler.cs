using Em.Core.Application.CQRS.Organization.Queries;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Queries
{
    public class GetAllCompanyQueryHandler : IRequestHandler<GetAllCompanyQuery, IReadOnlyList<GetAllCompanyDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllCompanyQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllCompanyDto>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<Company>(cancellationToken);

            return entities
                .Select(DtoMapper.Map<Company, GetAllCompanyDto>)
                .ToList();
        }
    }
}
