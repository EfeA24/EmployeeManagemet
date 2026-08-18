using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetByIdTicketApprovalPermissionQueryHandler : IRequestHandler<GetByIdTicketApprovalPermissionQuery, GetByIdTicketApprovalPermissionDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdTicketApprovalPermissionQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdTicketApprovalPermissionDto?> Handle(GetByIdTicketApprovalPermissionQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<TicketApprovalPermission>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return entity.ToGetByIdDto();
        }
    }
}
