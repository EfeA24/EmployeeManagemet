using Em.Core.Application.DTOs.CreateDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Attendance
{
    public class CreateAttendanceRecordCommand : IRequest<Guid>
    {
        public CreateAttendanceRecordDto CreateAttendanceRecordDto { get; set; } = null!;
    }
}
