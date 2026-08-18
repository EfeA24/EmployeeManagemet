using MediatR;

namespace Em.Core.Application.CQRS.Commands.Identity
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
