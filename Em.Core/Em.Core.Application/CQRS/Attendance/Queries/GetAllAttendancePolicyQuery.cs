using Em.Core.Application.DTOs.ReadDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Queries
{
    public class GetAllAttendancePolicyQuery : IRequest<IReadOnlyList<GetAllAttendancePolicyDto>>
    {
    }
}
