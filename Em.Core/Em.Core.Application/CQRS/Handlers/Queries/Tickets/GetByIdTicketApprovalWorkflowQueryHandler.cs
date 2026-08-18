using MediatR;
using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Domain.Entities.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetByIdTicketApprovalWorkflowQueryHandler : IRequestHandler<GetByIdTicketApprovalWorkflowQuery, GetByIdTicketApprovalWorkflowDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdTicketApprovalWorkflowQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdTicketApprovalWorkflowDto?> Handle(GetByIdTicketApprovalWorkflowQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketApprovalWorkflowRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<TicketApprovalWorkflow, GetByIdTicketApprovalWorkflowDto>(entity);
}
}
}
