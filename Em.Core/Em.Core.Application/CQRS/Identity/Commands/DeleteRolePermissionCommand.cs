using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
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
