using Em.Core.Application.DTOs.UpdateDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Attendance
{
    public class UpdateAttendanceCorrectionCommand : IRequest
    {
        public UpdateAttendanceCorrectionDto UpdateAttendanceCorrectionDto { get; set; } = null!;
    }
}
