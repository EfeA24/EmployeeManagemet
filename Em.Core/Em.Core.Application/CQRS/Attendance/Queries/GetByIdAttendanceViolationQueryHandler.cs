using Em.Core.Application.CQRS.Attendance.Queries;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Queries
{
    public class GetByIdAttendanceViolationQueryHandler : IRequestHandler<GetByIdAttendanceViolationQuery, GetByIdAttendanceViolationDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdAttendanceViolationQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdAttendanceViolationDto?> Handle(GetByIdAttendanceViolationQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<AttendanceViolation>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<AttendanceViolation, GetByIdAttendanceViolationDto>(entity);
        }
    }
}
