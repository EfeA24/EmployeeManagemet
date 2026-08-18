using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Commands
{
    public class DeleteAttendanceRecordCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteAttendanceRecordCommand(Guid id)
        {
            Id = id;
        }
    }
}
