using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
{
    public class DeleteRoleCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteRoleCommand(Guid id)
        {
            Id = id;
        }
    }
}
