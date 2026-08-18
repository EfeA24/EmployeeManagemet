using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetAllApprovalDelegationQueryHandler : IRequestHandler<GetAllApprovalDelegationQuery, IReadOnlyList<GetAllApprovalDelegationDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllApprovalDelegationQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllApprovalDelegationDto>> Handle(GetAllApprovalDelegationQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<ApprovalDelegation>(cancellationToken);

            return entities
                .Select(x => x.ToGetAllDto())
                .ToList();
        }
    }
}
