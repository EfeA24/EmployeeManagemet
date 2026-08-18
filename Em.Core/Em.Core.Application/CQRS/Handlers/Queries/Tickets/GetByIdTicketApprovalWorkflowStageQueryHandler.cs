using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetByIdTicketApprovalWorkflowStageQueryHandler : IRequestHandler<GetByIdTicketApprovalWorkflowStageQuery, GetByIdTicketApprovalWorkflowStageDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdTicketApprovalWorkflowStageQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdTicketApprovalWorkflowStageDto?> Handle(GetByIdTicketApprovalWorkflowStageQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<TicketApprovalWorkflowStage>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return entity.ToGetByIdDto();
        }
    }
}
