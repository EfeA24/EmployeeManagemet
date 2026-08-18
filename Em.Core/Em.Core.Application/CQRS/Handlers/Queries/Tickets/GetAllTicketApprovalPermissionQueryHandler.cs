using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetAllTicketApprovalPermissionQueryHandler : IRequestHandler<GetAllTicketApprovalPermissionQuery, IReadOnlyList<GetAllTicketApprovalPermissionDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllTicketApprovalPermissionQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllTicketApprovalPermissionDto>> Handle(GetAllTicketApprovalPermissionQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<TicketApprovalPermission>(cancellationToken);

            return entities
                .Select(x => x.ToGetAllDto())
                .ToList();
        }
    }
}
