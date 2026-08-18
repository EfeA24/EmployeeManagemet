using Em.Core.Application.DTOs.UpdateDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Organization
{
    public class UpdateEmployeeDepartmentHistoryCommand : IRequest
    {
        public UpdateEmployeeDepartmentHistoryDto UpdateEmployeeDepartmentHistoryDto { get; set; } = null!;
    }
}
