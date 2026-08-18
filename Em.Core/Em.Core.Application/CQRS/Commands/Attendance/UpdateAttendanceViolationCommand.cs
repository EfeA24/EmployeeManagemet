using Em.Core.Application.DTOs.UpdateDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Attendance
{
    public class UpdateAttendanceViolationCommand : IRequest
    {
        public UpdateAttendanceViolationDto UpdateAttendanceViolationDto { get; set; } = null!;
    }
}
