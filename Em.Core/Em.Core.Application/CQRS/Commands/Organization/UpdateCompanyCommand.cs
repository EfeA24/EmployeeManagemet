using Em.Core.Application.DTOs.UpdateDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Organization
{
    public class UpdateCompanyCommand : IRequest
    {
        public UpdateCompanyDto UpdateCompanyDto { get; set; } = null!;
    }
}
