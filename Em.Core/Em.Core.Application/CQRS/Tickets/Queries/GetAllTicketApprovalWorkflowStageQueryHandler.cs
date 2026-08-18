using Em.Core.Application.CQRS.Tickets.Queries;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Queries
{
    public class GetAllTicketApprovalWorkflowStageQueryHandler : IRequestHandler<GetAllTicketApprovalWorkflowStageQuery, IReadOnlyList<GetAllTicketApprovalWorkflowStageDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllTicketApprovalWorkflowStageQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllTicketApprovalWorkflowStageDto>> Handle(GetAllTicketApprovalWorkflowStageQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<TicketApprovalWorkflowStage>(cancellationToken);

            return entities
                .Select(DtoMapper.Map<TicketApprovalWorkflowStage, GetAllTicketApprovalWorkflowStageDto>)
                .ToList();
        }
    }
}
