using Em.Core.Application.DTOs.CreateDtos.Assets;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Assets
{
    public class CreateAssetAssignmentCommand : IRequest<Guid>
    {
        public CreateAssetAssignmentDto CreateAssetAssignmentDto { get; set; } = null!;
    }
}
