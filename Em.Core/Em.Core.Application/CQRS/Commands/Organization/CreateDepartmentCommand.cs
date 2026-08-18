using Em.Core.Application.DTOs.CreateDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Organization
{
    public class CreateDepartmentCommand : IRequest<Guid>
    {
        public CreateDepartmentDto CreateDepartmentDto { get; set; } = null!;
    }
}
