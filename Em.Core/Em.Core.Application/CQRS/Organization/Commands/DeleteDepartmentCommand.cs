using MediatR;

namespace Em.Core.Application.CQRS.Organization.Commands
{
    public class DeleteDepartmentCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteDepartmentCommand(Guid id)
        {
            Id = id;
        }
    }
}
