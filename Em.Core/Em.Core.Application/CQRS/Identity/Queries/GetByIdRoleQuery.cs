using Em.Core.Application.DTOs.ReadDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Queries
{
    public class GetByIdRoleQuery : IRequest<GetByIdRoleDto?>
    {
        public Guid Id { get; set; }

        public GetByIdRoleQuery(Guid id)
        {
            Id = id;
        }
    }
}
