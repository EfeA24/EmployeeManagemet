using Em.Core.Application.DTOs.ReadDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Organization
{
    public class GetByIdEmployeeDepartmentHistoryQuery : IRequest<GetByIdEmployeeDepartmentHistoryDto?>
    {
        public Guid Id { get; set; }

        public GetByIdEmployeeDepartmentHistoryQuery(Guid id)
        {
            Id = id;
        }
    }
}
