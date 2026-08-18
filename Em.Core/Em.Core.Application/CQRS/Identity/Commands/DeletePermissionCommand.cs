using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
{
    public class DeletePermissionCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeletePermissionCommand(Guid id)
        {
            Id = id;
        }
    }
}
