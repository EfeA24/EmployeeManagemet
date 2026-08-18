using Em.Core.Application.CQRS.Queries.Attendance;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Attendance
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
                .Select(x => x.ToGetAllDto())
                .ToList();
        }
    }
}
