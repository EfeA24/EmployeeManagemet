using Em.Core.Application.DTOs.UpdateDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Identity
{
    public class UpdatePermissionCommand : IRequest
    {
        public UpdatePermissionDto UpdatePermissionDto { get; set; } = null!;
    }
}
