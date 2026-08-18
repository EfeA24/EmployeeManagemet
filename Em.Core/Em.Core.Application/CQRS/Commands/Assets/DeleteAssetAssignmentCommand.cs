using MediatR;

namespace Em.Core.Application.CQRS.Commands.Assets
{
    public class DeleteAssetAssignmentCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteAssetAssignmentCommand(Guid id)
        {
            Id = id;
        }
    }
}
