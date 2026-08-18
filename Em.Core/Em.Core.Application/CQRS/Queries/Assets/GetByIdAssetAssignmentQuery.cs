using Em.Core.Application.DTOs.ReadDtos.Assets;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Assets
{
    public class GetByIdAssetAssignmentQuery : IRequest<GetByIdAssetAssignmentDto?>
    {
        public Guid Id { get; set; }

        public GetByIdAssetAssignmentQuery(Guid id)
        {
            Id = id;
        }
    }
}
