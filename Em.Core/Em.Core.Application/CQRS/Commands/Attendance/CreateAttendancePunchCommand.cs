using Em.Core.Application.DTOs.CreateDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Attendance
{
    public class CreateAttendancePunchCommand : IRequest<Guid>
    {
        public CreateAttendancePunchDto CreateAttendancePunchDto { get; set; } = null!;
    }
}
