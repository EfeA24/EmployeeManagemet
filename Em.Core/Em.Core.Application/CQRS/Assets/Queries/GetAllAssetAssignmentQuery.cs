using Em.Core.Application.DTOs.ReadDtos.Assets;
using MediatR;

namespace Em.Core.Application.CQRS.Assets.Queries
{
    public class GetAllAssetAssignmentQuery : IRequest<IReadOnlyList<GetAllAssetAssignmentDto>>
    {
    }
}
