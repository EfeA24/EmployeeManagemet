using Em.Core.Application.CQRS.Leave.Queries;
using Em.Core.Application.DTOs.ReadDtos.Leave;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Leave;
using MediatR;

namespace Em.Core.Application.CQRS.Leave.Queries
{
    public class GetAllLeaveBalanceQueryHandler : IRequestHandler<GetAllLeaveBalanceQuery, IReadOnlyList<GetAllLeaveBalanceDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllLeaveBalanceQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllLeaveBalanceDto>> Handle(GetAllLeaveBalanceQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<LeaveBalance>(cancellationToken);

            return entities
                .Select(DtoMapper.Map<LeaveBalance, GetAllLeaveBalanceDto>)
                .ToList();
        }
    }
}
