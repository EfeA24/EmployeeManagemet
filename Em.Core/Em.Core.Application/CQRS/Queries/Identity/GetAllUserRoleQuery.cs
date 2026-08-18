using Em.Core.Application.DTOs.ReadDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Identity
{
    public class GetAllUserRoleQuery : IRequest<IReadOnlyList<GetAllUserRoleDto>>
    {
    }
}
