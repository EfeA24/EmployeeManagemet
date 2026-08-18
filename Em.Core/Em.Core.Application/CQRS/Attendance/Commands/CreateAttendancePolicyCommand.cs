using Em.Core.Application.DTOs.CreateDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Commands
{
    public class CreateAttendancePolicyCommand : IRequest<Guid>
    {
        public CreateAttendancePolicyDto CreateAttendancePolicyDto { get; set; } = null!;
    }
}
