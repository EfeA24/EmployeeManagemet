using MediatR;

namespace Em.Core.Application.CQRS.Commands.Attendance
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
