using Em.Core.Application.CQRS.Attendance.Queries;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Queries
{
    public class GetAllAttendanceViolationQueryHandler : IRequestHandler<GetAllAttendanceViolationQuery, IReadOnlyList<GetAllAttendanceViolationDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllAttendanceViolationQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllAttendanceViolationDto>> Handle(GetAllAttendanceViolationQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<AttendanceViolation>(cancellationToken);

            return entities
                .Select(DtoMapper.Map<AttendanceViolation, GetAllAttendanceViolationDto>)
                .ToList();
        }
    }
}
