using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Commands
{
    public class DeleteAttendanceCorrectionCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteAttendanceCorrectionCommand(Guid id)
        {
            Id = id;
        }
    }
}
