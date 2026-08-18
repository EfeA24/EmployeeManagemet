using Em.Core.Application.CQRS.Queries.Attendance;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Attendance
{
    public class GetAllAttendancePolicyQueryHandler : IRequestHandler<GetAllAttendancePolicyQuery, IReadOnlyList<GetAllAttendancePolicyDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllAttendancePolicyQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllAttendancePolicyDto>> Handle(GetAllAttendancePolicyQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<AttendancePolicy>(cancellationToken);

            return entities
                .Select(x => x.ToGetAllDto())
                .ToList();
        }
    }
}
