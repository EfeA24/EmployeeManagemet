using Em.Core.Application.CQRS.Queries.Audit;
using Em.Core.Application.DTOs.ReadDtos.Audit;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Audit;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Audit
{
    public class GetByIdAuditLogQueryHandler : IRequestHandler<GetByIdAuditLogQuery, GetByIdAuditLogDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdAuditLogQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdAuditLogDto?> Handle(GetByIdAuditLogQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<AuditLog>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return entity.ToGetByIdDto();
        }
    }
}
