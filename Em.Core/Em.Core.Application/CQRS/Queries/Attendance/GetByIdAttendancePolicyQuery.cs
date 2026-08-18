using Em.Core.Application.DTOs.ReadDtos.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Attendance
{
    public class GetByIdAttendancePolicyQuery : IRequest<GetByIdAttendancePolicyDto?>
    {
        public Guid Id { get; set; }

        public GetByIdAttendancePolicyQuery(Guid id)
        {
            Id = id;
        }
    }
}
