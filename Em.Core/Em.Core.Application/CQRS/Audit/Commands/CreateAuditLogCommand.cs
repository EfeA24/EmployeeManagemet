using Em.Core.Application.DTOs.CreateDtos.Audit;
using MediatR;

namespace Em.Core.Application.CQRS.Audit.Commands
{
    public class CreateAuditLogCommand : IRequest<Guid>
    {
        public CreateAuditLogDto CreateAuditLogDto { get; set; } = null!;
    }
}
