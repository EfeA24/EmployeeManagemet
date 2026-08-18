using Em.Core.Application.DTOs.ReadDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Attendance
{
    public class GetAllAttendancePolicyQuery : IRequest<IReadOnlyList<GetAllAttendancePolicyDto>>
    {
    }
}
