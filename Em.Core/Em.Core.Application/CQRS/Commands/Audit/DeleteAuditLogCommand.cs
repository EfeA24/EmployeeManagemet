using MediatR;

namespace Em.Core.Application.CQRS.Commands.Audit
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
