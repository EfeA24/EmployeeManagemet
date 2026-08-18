using Em.Core.Application.DTOs.ReadDtos.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Organization
{
    public class GetAllEmployeeQuery : IRequest<IReadOnlyList<GetAllEmployeeDto>>
    {
    }
}
