using Em.Core.Application.DTOs.ReadDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Identity
{
    public class GetByIdPermissionQuery : IRequest<GetByIdPermissionDto?>
    {
        public Guid Id { get; set; }

        public GetByIdPermissionQuery(Guid id)
        {
            Id = id;
        }
    }
}
