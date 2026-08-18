using MediatR;

namespace Em.Core.Application.CQRS.Organization.Commands
{
    public class DeleteEmployeeCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteEmployeeCommand(Guid id)
        {
            Id = id;
        }
    }
}
