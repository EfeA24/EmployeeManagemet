using MediatR;

namespace Em.Core.Application.CQRS.Commands.Identity
{
    public class DeleteRolePermissionCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteRolePermissionCommand(Guid id)
        {
            Id = id;
        }
    }
}
