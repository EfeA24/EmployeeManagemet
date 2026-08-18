using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Commands
{
    public class DeleteAttendancePunchCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteAttendancePunchCommand(Guid id)
        {
            Id = id;
        }
    }
}
