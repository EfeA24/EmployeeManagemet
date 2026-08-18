using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetByIdApprovalDelegationQueryHandler : IRequestHandler<GetByIdApprovalDelegationQuery, GetByIdApprovalDelegationDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdApprovalDelegationQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdApprovalDelegationDto?> Handle(GetByIdApprovalDelegationQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<ApprovalDelegation>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return entity.ToGetByIdDto();
        }
    }
}
