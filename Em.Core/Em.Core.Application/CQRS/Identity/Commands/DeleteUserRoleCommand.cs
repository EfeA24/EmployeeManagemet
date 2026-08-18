using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
{
    public class DeleteUserRoleCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteUserRoleCommand(Guid id)
        {
            Id = id;
        }
    }
}
