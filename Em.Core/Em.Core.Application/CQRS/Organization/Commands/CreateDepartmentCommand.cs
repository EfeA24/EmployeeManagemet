using Em.Core.Application.DTOs.CreateDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Commands
{
    public class CreateDepartmentCommand : IRequest<Guid>
    {
        public CreateDepartmentDto CreateDepartmentDto { get; set; } = null!;
    }
}
