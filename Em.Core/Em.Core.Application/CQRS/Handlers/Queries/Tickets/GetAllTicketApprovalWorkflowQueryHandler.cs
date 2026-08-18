using MediatR;
using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Domain.Entities.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetAllTicketApprovalWorkflowQueryHandler : IRequestHandler<GetAllTicketApprovalWorkflowQuery, IReadOnlyList<GetAllTicketApprovalWorkflowDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTicketApprovalWorkflowQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllTicketApprovalWorkflowDto>> Handle(GetAllTicketApprovalWorkflowQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.TicketApprovalWorkflowRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<TicketApprovalWorkflow, GetAllTicketApprovalWorkflowDto>)
                .ToList();
}
}
}
