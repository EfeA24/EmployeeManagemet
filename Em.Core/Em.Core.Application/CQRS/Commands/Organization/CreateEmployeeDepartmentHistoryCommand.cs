using Em.Core.Application.DTOs.CreateDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Organization
{
    public class CreateEmployeeDepartmentHistoryCommand : IRequest<Guid>
    {
        public CreateEmployeeDepartmentHistoryDto CreateEmployeeDepartmentHistoryDto { get; set; } = null!;
    }
}
