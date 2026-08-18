using Em.Core.Application.DTOs.CreateDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Attendance
{
    public class CreateAttendanceCorrectionCommand : IRequest<Guid>
    {
        public CreateAttendanceCorrectionDto CreateAttendanceCorrectionDto { get; set; } = null!;
    }
}
