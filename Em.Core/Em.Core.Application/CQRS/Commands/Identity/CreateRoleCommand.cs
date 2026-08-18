using Em.Core.Application.DTOs.CreateDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Identity
{
    public class CreateRoleCommand : IRequest<Guid>
    {
        public CreateRoleDto CreateRoleDto { get; set; } = null!;
    }
}
