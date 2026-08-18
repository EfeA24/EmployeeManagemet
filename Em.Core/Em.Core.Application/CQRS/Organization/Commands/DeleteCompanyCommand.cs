using MediatR;

namespace Em.Core.Application.CQRS.Organization.Commands
{
    public class DeleteCompanyCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteCompanyCommand(Guid id)
        {
            Id = id;
        }
    }
}
