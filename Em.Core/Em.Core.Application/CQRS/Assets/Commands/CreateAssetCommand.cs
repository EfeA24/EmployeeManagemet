using Em.Core.Application.DTOs.CreateDtos.Assets;
using MediatR;

namespace Em.Core.Application.CQRS.Assets.Commands
{
    public class CreateAssetCommand : IRequest<Guid>
    {
        public CreateAssetDto CreateAssetDto { get; set; } = null!;
    }
}
