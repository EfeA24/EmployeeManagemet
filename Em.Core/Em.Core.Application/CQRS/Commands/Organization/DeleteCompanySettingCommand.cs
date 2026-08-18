using MediatR;

namespace Em.Core.Application.CQRS.Commands.Organization
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
