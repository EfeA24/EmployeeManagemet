using Em.Core.Application.DTOs.UpdateDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Commands
{
    public class UpdateCompanyCommand : IRequest
    {
        public UpdateCompanyDto UpdateCompanyDto { get; set; } = null!;
    }
}
