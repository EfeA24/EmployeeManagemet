using Em.Core.Application.DTOs.ReadDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Queries
{
    public class GetByIdAttendanceViolationQuery : IRequest<GetByIdAttendanceViolationDto?>
    {
        public Guid Id { get; set; }

        public GetByIdAttendanceViolationQuery(Guid id)
        {
            Id = id;
        }
    }
}
