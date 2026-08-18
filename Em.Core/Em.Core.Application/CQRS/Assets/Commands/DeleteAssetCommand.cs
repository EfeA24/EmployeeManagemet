using MediatR;

namespace Em.Core.Application.CQRS.Assets.Commands
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
