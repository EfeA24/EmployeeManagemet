using MediatR;

namespace Em.Core.Application.CQRS.Organization.Commands
{
    public class DeleteCompanySettingCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteCompanySettingCommand(Guid id)
        {
            Id = id;
        }
    }
}
