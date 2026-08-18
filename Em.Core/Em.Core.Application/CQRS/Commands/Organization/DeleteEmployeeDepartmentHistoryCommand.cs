using MediatR;

namespace Em.Core.Application.CQRS.Commands.Organization
{
    public class DeleteEmployeeDepartmentHistoryCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteEmployeeDepartmentHistoryCommand(Guid id)
        {
            Id = id;
        }
    }
}
