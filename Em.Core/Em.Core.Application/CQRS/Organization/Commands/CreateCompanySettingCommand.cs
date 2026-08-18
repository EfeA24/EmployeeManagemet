using Em.Core.Application.DTOs.CreateDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Commands
{
    public class CreateCompanySettingCommand : IRequest<Guid>
    {
        public CreateCompanySettingDto CreateCompanySettingDto { get; set; } = null!;
    }
}
