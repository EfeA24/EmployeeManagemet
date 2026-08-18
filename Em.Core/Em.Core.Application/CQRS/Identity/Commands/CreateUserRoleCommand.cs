using Em.Core.Application.DTOs.CreateDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
{
    public class CreateUserRoleCommand : IRequest<Guid>
    {
        public CreateUserRoleDto CreateUserRoleDto { get; set; } = null!;
    }
}
