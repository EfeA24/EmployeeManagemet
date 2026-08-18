using Em.Core.Application.DTOs.CreateDtos.Assets;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Assets
{
    public class CreateAssetCommand : IRequest<Guid>
    {
        public CreateAssetDto CreateAssetDto { get; set; } = null!;
    }
}
