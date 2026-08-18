using MediatR;

namespace Em.Core.Application.CQRS.Commands.Attendance
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
