using Em.Core.Application.DTOs.UpdateDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
{
    public class UpdateRoleCommand : IRequest
    {
        public UpdateRoleDto UpdateRoleDto { get; set; } = null!;
    }
}
