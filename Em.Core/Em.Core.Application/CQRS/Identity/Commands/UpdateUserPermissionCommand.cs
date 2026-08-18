using Em.Core.Application.DTOs.UpdateDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
{
    public class UpdateUserPermissionCommand : IRequest
    {
        public UpdateUserPermissionDto UpdateUserPermissionDto { get; set; } = null!;
    }
}
