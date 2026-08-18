using Em.Core.Application.DTOs.UpdateDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
{
    public class UpdatePermissionCommand : IRequest
    {
        public UpdatePermissionDto UpdatePermissionDto { get; set; } = null!;
    }
}
