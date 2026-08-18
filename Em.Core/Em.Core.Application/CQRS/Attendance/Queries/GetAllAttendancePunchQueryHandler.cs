using Em.Core.Application.CQRS.Attendance.Queries;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Queries
{
    public class GetAllAttendancePunchQueryHandler : IRequestHandler<GetAllAttendancePunchQuery, IReadOnlyList<GetAllAttendancePunchDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllAttendancePunchQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllAttendancePunchDto>> Handle(GetAllAttendancePunchQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<AttendancePunch>(cancellationToken);

            return entities
                .Select(DtoMapper.Map<AttendancePunch, GetAllAttendancePunchDto>)
                .ToList();
        }
    }
}
