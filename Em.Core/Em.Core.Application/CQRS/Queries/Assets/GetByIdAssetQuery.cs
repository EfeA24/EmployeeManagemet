using Em.Core.Application.DTOs.ReadDtos.Assets;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Assets
{
    public class GetByIdAssetQuery : IRequest<GetByIdAssetDto?>
    {
        public Guid Id { get; set; }

        public GetByIdAssetQuery(Guid id)
        {
            Id = id;
        }
    }
}
