using MediatR;
using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Domain.Entities.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetAllTicketApprovalWorkflowStageQueryHandler : IRequestHandler<GetAllTicketApprovalWorkflowStageQuery, IReadOnlyList<GetAllTicketApprovalWorkflowStageDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTicketApprovalWorkflowStageQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllTicketApprovalWorkflowStageDto>> Handle(GetAllTicketApprovalWorkflowStageQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.TicketApprovalWorkflowStageRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<TicketApprovalWorkflowStage, GetAllTicketApprovalWorkflowStageDto>)
                .ToList();
}
}
}
