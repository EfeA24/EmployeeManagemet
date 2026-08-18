using Em.Core.Application.DTOs.UpdateDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Attendance
{
    public class UpdateAttendancePunchCommand : IRequest
    {
        public UpdateAttendancePunchDto UpdateAttendancePunchDto { get; set; } = null!;
    }
}
