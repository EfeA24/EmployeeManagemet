using MediatR;

namespace Em.Core.Application.CQRS.Organization.Commands
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
