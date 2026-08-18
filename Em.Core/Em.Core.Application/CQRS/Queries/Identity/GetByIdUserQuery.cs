using Em.Core.Application.DTOs.ReadDtos.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Identity
{
    public class GetByIdUserQuery : IRequest<GetByIdUserDto?>
    {
        public Guid Id { get; set; }

        public GetByIdUserQuery(Guid id)
        {
            Id = id;
        }
    }
}
