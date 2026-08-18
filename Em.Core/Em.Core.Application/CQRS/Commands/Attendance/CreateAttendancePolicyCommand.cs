using Em.Core.Application.DTOs.CreateDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Attendance
{
    public class CreateAttendancePolicyCommand : IRequest<Guid>
    {
        public CreateAttendancePolicyDto CreateAttendancePolicyDto { get; set; } = null!;
    }
}
