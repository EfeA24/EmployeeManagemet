using MediatR;

namespace Em.Core.Application.CQRS.Commands.Organization
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
