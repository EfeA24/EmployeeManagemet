using Em.Core.Application.DTOs.ReadDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Organization
{
    public class GetAllEmployeeDepartmentHistoryQuery : IRequest<IReadOnlyList<GetAllEmployeeDepartmentHistoryDto>>
    {
    }
}
