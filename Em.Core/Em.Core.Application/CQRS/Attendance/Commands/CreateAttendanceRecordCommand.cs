using Em.Core.Application.DTOs.CreateDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Commands
{
    public class CreateAttendanceRecordCommand : IRequest<Guid>
    {
        public CreateAttendanceRecordDto CreateAttendanceRecordDto { get; set; } = null!;
    }
}
