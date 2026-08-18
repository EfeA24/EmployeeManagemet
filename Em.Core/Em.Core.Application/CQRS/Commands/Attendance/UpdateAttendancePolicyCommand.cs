using Em.Core.Application.DTOs.UpdateDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Attendance
{
    public class UpdateAttendancePolicyCommand : IRequest
    {
        public UpdateAttendancePolicyDto UpdateAttendancePolicyDto { get; set; } = null!;
    }
}
