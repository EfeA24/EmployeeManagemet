using Em.Core.Application.DTOs.ReadDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Identity
{
    public class GetByIdRolePermissionQuery : IRequest<GetByIdRolePermissionDto?>
    {
        public Guid Id { get; set; }

        public GetByIdRolePermissionQuery(Guid id)
        {
            Id = id;
        }
    }
}
