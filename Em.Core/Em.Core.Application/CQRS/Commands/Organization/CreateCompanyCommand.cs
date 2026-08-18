using Em.Core.Application.DTOs.CreateDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Organization
{
    public class CreateCompanyCommand : IRequest<Guid>
    {
        public CreateCompanyDto CreateCompanyDto { get; set; } = null!;
    }
}
