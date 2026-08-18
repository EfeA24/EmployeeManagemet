using Em.Core.Application.DTOs.CreateDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Identity
{
    public class CreateUserPermissionCommand : IRequest<Guid>
    {
        public CreateUserPermissionDto CreateUserPermissionDto { get; set; } = null!;
    }
}
