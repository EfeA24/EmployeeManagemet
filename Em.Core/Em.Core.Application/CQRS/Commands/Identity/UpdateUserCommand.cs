using Em.Core.Application.DTOs.UpdateDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Identity
{
    public class UpdateUserCommand : IRequest
    {
        public UpdateUserDto UpdateUserDto { get; set; } = null!;
    }
}
