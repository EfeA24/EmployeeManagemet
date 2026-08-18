using Em.Core.Application.DTOs.ReadDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Attendance
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
