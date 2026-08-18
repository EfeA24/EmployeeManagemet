using Em.Core.Application.DTOs.UpdateDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Commands
{
    public class UpdateCompanySettingCommand : IRequest
    {
        public UpdateCompanySettingDto UpdateCompanySettingDto { get; set; } = null!;
    }
}
