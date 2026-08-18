using Em.Core.Application.DTOs.UpdateDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Commands
{
    public class UpdateAttendancePunchCommand : IRequest
    {
        public UpdateAttendancePunchDto UpdateAttendancePunchDto { get; set; } = null!;
    }
}
