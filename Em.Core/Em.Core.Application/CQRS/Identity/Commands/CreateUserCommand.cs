using Em.Core.Application.DTOs.CreateDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public CreateUserDto CreateUserDto { get; set; } = null!;
    }
}
