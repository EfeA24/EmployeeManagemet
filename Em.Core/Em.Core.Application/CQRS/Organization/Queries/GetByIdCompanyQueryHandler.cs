using Em.Core.Application.CQRS.Organization.Queries;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Queries
{
    public class GetByIdCompanyQueryHandler : IRequestHandler<GetByIdCompanyQuery, GetByIdCompanyDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdCompanyQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdCompanyDto?> Handle(GetByIdCompanyQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<Company>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<Company, GetByIdCompanyDto>(entity);
        }
    }
}
