using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class DeleteTicketApprovalPermissionCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteTicketApprovalPermissionCommand(Guid id)
        {
            Id = id;
        }
    }
}
