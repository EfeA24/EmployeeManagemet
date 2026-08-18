using Em.Core.Application.DTOs.CreateDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Identity
{
    public class CreateRolePermissionCommand : IRequest<Guid>
    {
        public CreateRolePermissionDto CreateRolePermissionDto { get; set; } = null!;
    }
}
