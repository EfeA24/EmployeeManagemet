using Em.Core.Application.DTOs.CreateDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
{
    public class CreateUserPermissionCommand : IRequest<Guid>
    {
        public CreateUserPermissionDto CreateUserPermissionDto { get; set; } = null!;
    }
}
