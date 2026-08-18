using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Commands
{
    public class DeleteAttendanceViolationCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteAttendanceViolationCommand(Guid id)
        {
            Id = id;
        }
    }
}
