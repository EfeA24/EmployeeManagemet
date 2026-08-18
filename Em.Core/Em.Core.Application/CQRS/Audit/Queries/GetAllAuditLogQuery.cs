using Em.Core.Application.DTOs.ReadDtos.Audit;
using MediatR;

namespace Em.Core.Application.CQRS.Audit.Queries
{
    public class GetAllAuditLogQuery : IRequest<IReadOnlyList<GetAllAuditLogDto>>
    {
    }
}
