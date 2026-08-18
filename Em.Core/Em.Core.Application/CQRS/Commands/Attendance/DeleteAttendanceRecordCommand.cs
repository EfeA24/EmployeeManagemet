using MediatR;

namespace Em.Core.Application.CQRS.Commands.Attendance
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
