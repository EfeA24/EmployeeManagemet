using Em.Core.Application.DTOs.UpdateDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Organization
{
    public class UpdateEmployeeCommand : IRequest
    {
        public UpdateEmployeeDto UpdateEmployeeDto { get; set; } = null!;
    }
}
