using MediatR;

namespace Em.Core.Application.CQRS.Commands.Organization
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
