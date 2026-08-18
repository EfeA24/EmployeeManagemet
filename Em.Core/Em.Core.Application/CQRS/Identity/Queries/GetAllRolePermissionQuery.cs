using Em.Core.Application.DTOs.ReadDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Queries
{
    public class GetAllRolePermissionQuery : IRequest<IReadOnlyList<GetAllRolePermissionDto>>
    {
    }
}
