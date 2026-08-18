using Em.Core.Application.CQRS.Attendance.Queries;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Queries
{
    public class GetByIdAttendanceRecordQueryHandler : IRequestHandler<GetByIdAttendanceRecordQuery, GetByIdAttendanceRecordDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdAttendanceRecordQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdAttendanceRecordDto?> Handle(GetByIdAttendanceRecordQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<AttendanceRecord>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<AttendanceRecord, GetByIdAttendanceRecordDto>(entity);
        }
    }
}
