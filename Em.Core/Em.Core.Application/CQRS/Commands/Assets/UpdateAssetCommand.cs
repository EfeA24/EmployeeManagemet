using Em.Core.Application.DTOs.UpdateDtos.Assets;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Assets
{
    public class UpdateAssetCommand : IRequest
    {
        public UpdateAssetDto UpdateAssetDto { get; set; } = null!;
    }
}
