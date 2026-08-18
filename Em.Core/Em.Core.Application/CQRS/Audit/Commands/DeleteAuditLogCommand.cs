using MediatR;

namespace Em.Core.Application.CQRS.Audit.Commands
{
    public class DeleteAuditLogCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteAuditLogCommand(Guid id)
        {
            Id = id;
        }
    }
}
