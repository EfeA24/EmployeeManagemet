using MediatR;

namespace Em.Core.Application.CQRS.Commands.Identity
{
    public class DeleteUserPermissionCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteUserPermissionCommand(Guid id)
        {
            Id = id;
        }
    }
}
