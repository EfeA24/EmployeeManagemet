using Em.Core.Application.DTOs.CreateDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Commands
{
    public class CreateAttendanceCorrectionCommand : IRequest<Guid>
    {
        public CreateAttendanceCorrectionDto CreateAttendanceCorrectionDto { get; set; } = null!;
    }
}
