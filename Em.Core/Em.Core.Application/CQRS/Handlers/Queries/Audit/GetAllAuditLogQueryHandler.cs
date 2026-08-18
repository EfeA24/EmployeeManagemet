using Em.Core.Application.CQRS.Queries.Audit;
using Em.Core.Application.DTOs.ReadDtos.Audit;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Audit;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Audit
{
    public class GetAllAuditLogQueryHandler : IRequestHandler<GetAllAuditLogQuery, IReadOnlyList<GetAllAuditLogDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllAuditLogQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllAuditLogDto>> Handle(GetAllAuditLogQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<AuditLog>(cancellationToken);

            return entities
                .Select(x => x.ToGetAllDto())
                .ToList();
        }
    }
}
