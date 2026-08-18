using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetAllTicketApprovalWorkflowQueryHandler : IRequestHandler<GetAllTicketApprovalWorkflowQuery, IReadOnlyList<GetAllTicketApprovalWorkflowDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllTicketApprovalWorkflowQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllTicketApprovalWorkflowDto>> Handle(GetAllTicketApprovalWorkflowQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<TicketApprovalWorkflow>(cancellationToken);

            return entities
                .Select(x => x.ToGetAllDto())
                .ToList();
        }
    }
}
