using Em.Core.Application.DTOs.CreateDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Commands
{
    public class CreateAttendancePunchCommand : IRequest<Guid>
    {
        public CreateAttendancePunchDto CreateAttendancePunchDto { get; set; } = null!;
    }
}
