using Em.Core.Application.DTOs.UpdateDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Commands
{
    public class UpdateAttendanceRecordCommand : IRequest
    {
        public UpdateAttendanceRecordDto UpdateAttendanceRecordDto { get; set; } = null!;
    }
}
