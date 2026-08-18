using Em.Core.Application.CQRS.Attendance.Queries;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Queries
{
    public class GetAllAttendanceCorrectionQueryHandler : IRequestHandler<GetAllAttendanceCorrectionQuery, IReadOnlyList<GetAllAttendanceCorrectionDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllAttendanceCorrectionQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllAttendanceCorrectionDto>> Handle(GetAllAttendanceCorrectionQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<AttendanceCorrection>(cancellationToken);

            return entities
                .Select(DtoMapper.Map<AttendanceCorrection, GetAllAttendanceCorrectionDto>)
                .ToList();
        }
    }
}
