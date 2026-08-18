using MediatR;

namespace Em.Core.Application.CQRS.Commands.Assets
{
    public class DeleteAssetCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteAssetCommand(Guid id)
        {
            Id = id;
        }
    }
}
