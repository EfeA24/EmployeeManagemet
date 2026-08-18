using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class UpdateTicketApprovalWorkflowCommandHandler : IRequestHandler<UpdateTicketApprovalWorkflowCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTicketApprovalWorkflowCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateTicketApprovalWorkflowCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketApprovalWorkflowRepository.GetByIdAsync(request.UpdateTicketApprovalWorkflowDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateTicketApprovalWorkflowDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.TicketApprovalWorkflowRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
