using MediatR;

namespace Em.Core.Application.CQRS.Commands.Organization
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
