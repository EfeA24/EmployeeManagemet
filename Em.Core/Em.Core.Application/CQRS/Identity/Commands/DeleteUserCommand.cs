using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
    }
}
