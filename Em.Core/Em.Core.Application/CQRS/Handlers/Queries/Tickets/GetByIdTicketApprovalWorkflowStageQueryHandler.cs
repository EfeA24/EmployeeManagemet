using MediatR;
using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Domain.Entities.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetByIdTicketApprovalWorkflowStageQueryHandler : IRequestHandler<GetByIdTicketApprovalWorkflowStageQuery, GetByIdTicketApprovalWorkflowStageDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdTicketApprovalWorkflowStageQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdTicketApprovalWorkflowStageDto?> Handle(GetByIdTicketApprovalWorkflowStageQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketApprovalWorkflowStageRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<TicketApprovalWorkflowStage, GetByIdTicketApprovalWorkflowStageDto>(entity);
}
}
}
