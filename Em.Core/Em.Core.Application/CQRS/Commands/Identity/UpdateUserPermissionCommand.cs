using Em.Core.Application.DTOs.UpdateDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Identity
{
    public class UpdateUserPermissionCommand : IRequest
    {
        public UpdateUserPermissionDto UpdateUserPermissionDto { get; set; } = null!;
    }
}
