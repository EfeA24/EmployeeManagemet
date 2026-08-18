using Em.Core.Application.DTOs.UpdateDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
{
    public class UpdateUserCommand : IRequest
    {
        public UpdateUserDto UpdateUserDto { get; set; } = null!;
    }
}
