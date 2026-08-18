using Em.Core.Application.DTOs.ReadDtos.Assets;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Assets
{
    public class GetAllAssetAssignmentQuery : IRequest<IReadOnlyList<GetAllAssetAssignmentDto>>
    {
    }
}
