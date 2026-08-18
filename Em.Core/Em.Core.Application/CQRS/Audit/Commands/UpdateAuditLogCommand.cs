using Em.Core.Application.DTOs.UpdateDtos.Audit;
using MediatR;

namespace Em.Core.Application.CQRS.Audit.Commands
{
    public class UpdateAuditLogCommand : IRequest
    {
        public UpdateAuditLogDto UpdateAuditLogDto { get; set; } = null!;
    }
}
