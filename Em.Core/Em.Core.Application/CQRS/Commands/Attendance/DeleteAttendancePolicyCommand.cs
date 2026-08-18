using MediatR;

namespace Em.Core.Application.CQRS.Commands.Attendance
{
    public class DeleteAttendancePolicyCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteAttendancePolicyCommand(Guid id)
        {
            Id = id;
        }
    }
}
