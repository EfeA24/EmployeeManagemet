using Em.Core.Application.DTOs.UpdateDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Commands
{
    public class UpdateAttendancePolicyCommand : IRequest
    {
        public UpdateAttendancePolicyDto UpdateAttendancePolicyDto { get; set; } = null!;
    }
}
