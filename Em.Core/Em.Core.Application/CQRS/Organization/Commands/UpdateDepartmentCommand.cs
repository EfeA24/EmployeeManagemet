using Em.Core.Application.DTOs.UpdateDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Commands
{
    public class UpdateDepartmentCommand : IRequest
    {
        public UpdateDepartmentDto UpdateDepartmentDto { get; set; } = null!;
    }
}
