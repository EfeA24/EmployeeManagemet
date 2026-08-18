using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
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
