using Em.Core.Application.DTOs.CreateDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
{
    public class CreateRolePermissionCommand : IRequest<Guid>
    {
        public CreateRolePermissionDto CreateRolePermissionDto { get; set; } = null!;
    }
}
