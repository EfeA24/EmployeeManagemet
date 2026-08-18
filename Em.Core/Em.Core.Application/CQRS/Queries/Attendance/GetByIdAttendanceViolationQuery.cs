using Em.Core.Application.DTOs.ReadDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Attendance
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
