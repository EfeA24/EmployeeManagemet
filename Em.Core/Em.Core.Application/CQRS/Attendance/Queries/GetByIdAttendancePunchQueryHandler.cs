using Em.Core.Application.CQRS.Attendance.Queries;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Queries
{
    public class GetByIdAttendancePunchQueryHandler : IRequestHandler<GetByIdAttendancePunchQuery, GetByIdAttendancePunchDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdAttendancePunchQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdAttendancePunchDto?> Handle(GetByIdAttendancePunchQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<AttendancePunch>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<AttendancePunch, GetByIdAttendancePunchDto>(entity);
        }
    }
}
