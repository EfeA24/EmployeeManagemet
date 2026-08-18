using Em.Core.Application.DTOs.UpdateDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Identity
{
    public class UpdateRoleCommand : IRequest
    {
        public UpdateRoleDto UpdateRoleDto { get; set; } = null!;
    }
}
