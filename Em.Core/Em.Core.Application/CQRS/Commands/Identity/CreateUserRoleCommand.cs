using Em.Core.Application.DTOs.CreateDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Identity
{
    public class CreateUserRoleCommand : IRequest<Guid>
    {
        public CreateUserRoleDto CreateUserRoleDto { get; set; } = null!;
    }
}
