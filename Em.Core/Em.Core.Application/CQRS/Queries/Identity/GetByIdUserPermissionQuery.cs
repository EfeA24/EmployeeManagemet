using Em.Core.Application.DTOs.ReadDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Identity
{
    public class GetByIdUserPermissionQuery : IRequest<GetByIdUserPermissionDto?>
    {
        public Guid Id { get; set; }

        public GetByIdUserPermissionQuery(Guid id)
        {
            Id = id;
        }
    }
}
