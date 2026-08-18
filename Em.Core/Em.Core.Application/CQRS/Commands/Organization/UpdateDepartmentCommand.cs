using Em.Core.Application.DTOs.UpdateDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Organization
{
    public class UpdateDepartmentCommand : IRequest
    {
        public UpdateDepartmentDto UpdateDepartmentDto { get; set; } = null!;
    }
}
