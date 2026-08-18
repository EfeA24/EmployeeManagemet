using Em.Core.Application.DTOs.CreateDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Identity
{
    public class CreatePermissionCommand : IRequest<Guid>
    {
        public CreatePermissionDto CreatePermissionDto { get; set; } = null!;
    }
}
