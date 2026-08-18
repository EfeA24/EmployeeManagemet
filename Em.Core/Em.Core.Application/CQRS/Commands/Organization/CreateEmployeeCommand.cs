using Em.Core.Application.DTOs.CreateDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Organization
{
    public class CreateEmployeeCommand : IRequest<Guid>
    {
        public CreateEmployeeDto CreateEmployeeDto { get; set; } = null!;
    }
}
