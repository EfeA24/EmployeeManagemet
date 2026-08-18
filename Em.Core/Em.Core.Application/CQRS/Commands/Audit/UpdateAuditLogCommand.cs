using Em.Core.Application.DTOs.UpdateDtos.Audit;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Audit
{
    public class UpdateAuditLogCommand : IRequest
    {
        public UpdateAuditLogDto UpdateAuditLogDto { get; set; } = null!;
    }
}
