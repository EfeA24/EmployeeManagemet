using Em.Core.Application.DTOs.ReadDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Queries
{
    public class GetByIdEmployeeQuery : IRequest<GetByIdEmployeeDto?>
    {
        public Guid Id { get; set; }

        public GetByIdEmployeeQuery(Guid id)
        {
            Id = id;
        }
    }
}
