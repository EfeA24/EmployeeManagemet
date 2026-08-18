using Em.Core.Application.DTOs.ReadDtos.Audit;
using MediatR;

namespace Em.Core.Application.CQRS.Audit.Queries
{
    public class GetByIdAuditLogQuery : IRequest<GetByIdAuditLogDto?>
    {
        public Guid Id { get; set; }

        public GetByIdAuditLogQuery(Guid id)
        {
            Id = id;
        }
    }
}
