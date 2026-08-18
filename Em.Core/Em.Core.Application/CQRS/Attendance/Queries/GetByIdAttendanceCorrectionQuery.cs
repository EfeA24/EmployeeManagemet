using Em.Core.Application.DTOs.ReadDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Queries
{
    public class GetByIdAttendanceCorrectionQuery : IRequest<GetByIdAttendanceCorrectionDto?>
    {
        public Guid Id { get; set; }

        public GetByIdAttendanceCorrectionQuery(Guid id)
        {
            Id = id;
        }
    }
}
