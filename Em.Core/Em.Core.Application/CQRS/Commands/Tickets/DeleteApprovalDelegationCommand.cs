using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
{
    public class DeleteApprovalDelegationCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteApprovalDelegationCommand(Guid id)
        {
            Id = id;
        }
    }
}
