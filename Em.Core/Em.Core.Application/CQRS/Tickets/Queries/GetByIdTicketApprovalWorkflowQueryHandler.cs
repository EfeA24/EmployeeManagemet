using Em.Core.Application.CQRS.Tickets.Queries;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Queries
{
    public class GetByIdTicketApprovalWorkflowQueryHandler : IRequestHandler<GetByIdTicketApprovalWorkflowQuery, GetByIdTicketApprovalWorkflowDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdTicketApprovalWorkflowQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdTicketApprovalWorkflowDto?> Handle(GetByIdTicketApprovalWorkflowQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<TicketApprovalWorkflow>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<TicketApprovalWorkflow, GetByIdTicketApprovalWorkflowDto>(entity);
        }
    }
}
