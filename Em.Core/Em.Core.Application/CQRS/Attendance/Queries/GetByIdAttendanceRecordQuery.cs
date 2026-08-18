using Em.Core.Application.DTOs.ReadDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Queries
{
    public class GetByIdAttendanceRecordQuery : IRequest<GetByIdAttendanceRecordDto?>
    {
        public Guid Id { get; set; }

        public GetByIdAttendanceRecordQuery(Guid id)
        {
            Id = id;
        }
    }
}
