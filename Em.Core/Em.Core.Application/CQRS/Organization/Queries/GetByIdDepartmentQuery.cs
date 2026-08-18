using Em.Core.Application.DTOs.ReadDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Queries
{
    public class GetByIdDepartmentQuery : IRequest<GetByIdDepartmentDto?>
    {
        public Guid Id { get; set; }

        public GetByIdDepartmentQuery(Guid id)
        {
            Id = id;
        }
    }
}
