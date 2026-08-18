using Em.Core.Application.DTOs.CreateDtos.Audit;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Audit
{
    public class CreateAuditLogCommand : IRequest<Guid>
    {
        public CreateAuditLogDto CreateAuditLogDto { get; set; } = null!;
    }
}
