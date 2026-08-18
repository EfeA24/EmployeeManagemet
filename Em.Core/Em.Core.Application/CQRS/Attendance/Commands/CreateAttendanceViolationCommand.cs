using Em.Core.Application.DTOs.CreateDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Commands
{
    public class CreateAttendanceViolationCommand : IRequest<Guid>
    {
        public CreateAttendanceViolationDto CreateAttendanceViolationDto { get; set; } = null!;
    }
}
