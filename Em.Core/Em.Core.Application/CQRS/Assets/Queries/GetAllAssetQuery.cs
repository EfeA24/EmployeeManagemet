using Em.Core.Application.DTOs.ReadDtos.Assets;
using MediatR;

namespace Em.Core.Application.CQRS.Assets.Queries
{
    public class GetAllAssetQuery : IRequest<IReadOnlyList<GetAllAssetDto>>
    {
    }
}
