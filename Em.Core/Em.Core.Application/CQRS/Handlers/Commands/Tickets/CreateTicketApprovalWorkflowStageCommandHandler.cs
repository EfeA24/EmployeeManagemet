using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.CreateDtos.Tickets;
using Em.Core.Domain.Entities.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class CreateTicketApprovalWorkflowStageCommandHandler : IRequestHandler<CreateTicketApprovalWorkflowStageCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTicketApprovalWorkflowStageCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateTicketApprovalWorkflowStageCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateTicketApprovalWorkflowStageDto, TicketApprovalWorkflowStage>(request.CreateTicketApprovalWorkflowStageDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.TicketApprovalWorkflowStageRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
}
}
}
