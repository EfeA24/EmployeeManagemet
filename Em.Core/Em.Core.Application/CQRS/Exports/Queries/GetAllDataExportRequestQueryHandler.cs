using Em.Core.Application.CQRS.Exports.Queries;
using Em.Core.Application.DTOs.ReadDtos.Exports;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Exports;
using MediatR;

namespace Em.Core.Application.CQRS.Exports.Queries
{
    public class GetAllDataExportRequestQueryHandler : IRequestHandler<GetAllDataExportRequestQuery, IReadOnlyList<GetAllDataExportRequestDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllDataExportRequestQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllDataExportRequestDto>> Handle(GetAllDataExportRequestQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<DataExportRequest>(cancellationToken);

            return entities
                .Select(DtoMapper.Map<DataExportRequest, GetAllDataExportRequestDto>)
                .ToList();
        }
    }
}
