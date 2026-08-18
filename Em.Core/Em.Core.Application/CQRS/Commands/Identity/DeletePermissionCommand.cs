using MediatR;

namespace Em.Core.Application.CQRS.Commands.Identity
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
