using Em.Core.Application.CQRS.Queries.Organization;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Organization
{
    public class GetAllCompanySettingQueryHandler : IRequestHandler<GetAllCompanySettingQuery, IReadOnlyList<GetAllCompanySettingDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllCompanySettingQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllCompanySettingDto>> Handle(GetAllCompanySettingQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<CompanySetting>(cancellationToken);

            return entities
                .Select(x => x.ToGetAllDto())
                .ToList();
        }
    }
}
