using Em.Core.Application.CQRS.Attendance.Queries;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Queries
{
    public class GetAllAttendanceRecordQueryHandler : IRequestHandler<GetAllAttendanceRecordQuery, IReadOnlyList<GetAllAttendanceRecordDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllAttendanceRecordQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllAttendanceRecordDto>> Handle(GetAllAttendanceRecordQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<AttendanceRecord>(cancellationToken);

            return entities
                .Select(DtoMapper.Map<AttendanceRecord, GetAllAttendanceRecordDto>)
                .ToList();
        }
    }
}
