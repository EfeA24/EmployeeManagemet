using Em.Core.Application.CQRS.Tickets.Commands;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class UpdateTicketApprovalWorkflowStageCommandHandler : IRequestHandler<UpdateTicketApprovalWorkflowStageCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateTicketApprovalWorkflowStageCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
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

            var cached = DtoMapper.Map<TicketApprovalWorkflowStage, GetByIdTicketApprovalWorkflowStageDto>(entity);
            await _cache.SetAsync($"TicketApprovalWorkflowStage:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
