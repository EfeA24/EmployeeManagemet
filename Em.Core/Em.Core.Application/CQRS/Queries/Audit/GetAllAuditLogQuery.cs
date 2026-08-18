using Em.Core.Application.DTOs.ReadDtos.Audit;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Audit
{
    public class GetAllAuditLogQuery : IRequest<IReadOnlyList<GetAllAuditLogDto>>
    {
    }
}
