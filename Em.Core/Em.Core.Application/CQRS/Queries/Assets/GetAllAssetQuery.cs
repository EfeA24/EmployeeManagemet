using Em.Core.Application.DTOs.ReadDtos.Assets;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Assets
{
    public class GetAllAssetQuery : IRequest<IReadOnlyList<GetAllAssetDto>>
    {
    }
}
