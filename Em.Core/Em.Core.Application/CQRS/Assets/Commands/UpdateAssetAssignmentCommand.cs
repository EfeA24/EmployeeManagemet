using Em.Core.Application.DTOs.UpdateDtos.Assets;
using MediatR;

namespace Em.Core.Application.CQRS.Assets.Commands
{
    public class UpdateAssetAssignmentCommand : IRequest
    {
        public UpdateAssetAssignmentDto UpdateAssetAssignmentDto { get; set; } = null!;
    }
}
