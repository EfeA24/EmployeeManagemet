using Em.Core.Application.CQRS.Queries.Leave;
using Em.Core.Application.DTOs.ReadDtos.Leave;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Leave;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Leave
{
    public class GetByIdLeaveBalanceQueryHandler : IRequestHandler<GetByIdLeaveBalanceQuery, GetByIdLeaveBalanceDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdLeaveBalanceQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdLeaveBalanceDto?> Handle(GetByIdLeaveBalanceQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<LeaveBalance>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return entity.ToGetByIdDto();
        }
    }
}
