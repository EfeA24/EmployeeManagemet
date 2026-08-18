using MediatR;

namespace Em.Core.Application.CQRS.Commands.Identity
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
