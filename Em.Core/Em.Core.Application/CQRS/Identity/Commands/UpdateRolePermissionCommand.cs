using Em.Core.Application.DTOs.UpdateDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
{
    public class UpdateRolePermissionCommand : IRequest
    {
        public UpdateRolePermissionDto UpdateRolePermissionDto { get; set; } = null!;
    }
}
