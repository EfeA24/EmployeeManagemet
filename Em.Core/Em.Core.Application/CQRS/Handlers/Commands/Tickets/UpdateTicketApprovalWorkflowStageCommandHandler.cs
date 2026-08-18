using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class UpdateTicketApprovalWorkflowStageCommandHandler : IRequestHandler<UpdateTicketApprovalWorkflowStageCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTicketApprovalWorkflowStageCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateTicketApprovalWorkflowStageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketApprovalWorkflowStageRepository.GetByIdAsync(request.UpdateTicketApprovalWorkflowStageDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateTicketApprovalWorkflowStageDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.TicketApprovalWorkflowStageRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
