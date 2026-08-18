using Em.Core.Application.CQRS.Queries.Exports;
using Em.Core.Application.DTOs.ReadDtos.Exports;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Exports;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Exports
{
    public class GetByIdDataExportRequestQueryHandler : IRequestHandler<GetByIdDataExportRequestQuery, GetByIdDataExportRequestDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdDataExportRequestQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdDataExportRequestDto?> Handle(GetByIdDataExportRequestQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<DataExportRequest>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return entity.ToGetByIdDto();
        }
    }
}
