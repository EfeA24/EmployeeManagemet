using Em.Core.Application.DTOs.ReadDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Identity
{
    public class GetByIdUserRoleQuery : IRequest<GetByIdUserRoleDto?>
    {
        public Guid Id { get; set; }

        public GetByIdUserRoleQuery(Guid id)
        {
            Id = id;
        }
    }
}
