using Em.Core.Application.CQRS.Attendance.Queries;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Queries
{
    public class GetByIdAttendancePolicyQueryHandler : IRequestHandler<GetByIdAttendancePolicyQuery, GetByIdAttendancePolicyDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdAttendancePolicyQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdAttendancePolicyDto?> Handle(GetByIdAttendancePolicyQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<AttendancePolicy>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<AttendancePolicy, GetByIdAttendancePolicyDto>(entity);
        }
    }
}
