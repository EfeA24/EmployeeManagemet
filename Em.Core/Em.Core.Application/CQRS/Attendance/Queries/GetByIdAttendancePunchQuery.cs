using Em.Core.Application.DTOs.ReadDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Queries
{
    public class GetByIdAttendancePunchQuery : IRequest<GetByIdAttendancePunchDto?>
    {
        public Guid Id { get; set; }

        public GetByIdAttendancePunchQuery(Guid id)
        {
            Id = id;
        }
    }
}
