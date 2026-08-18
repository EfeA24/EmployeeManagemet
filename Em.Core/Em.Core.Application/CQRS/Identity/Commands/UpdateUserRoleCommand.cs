using Em.Core.Application.DTOs.UpdateDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
{
    public class UpdateUserRoleCommand : IRequest
    {
        public UpdateUserRoleDto UpdateUserRoleDto { get; set; } = null!;
    }
}
