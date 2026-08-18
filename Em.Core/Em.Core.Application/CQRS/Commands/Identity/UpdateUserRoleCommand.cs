using Em.Core.Application.DTOs.UpdateDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Identity
{
    public class UpdateUserRoleCommand : IRequest
    {
        public UpdateUserRoleDto UpdateUserRoleDto { get; set; } = null!;
    }
}
