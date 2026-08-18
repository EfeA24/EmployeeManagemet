using Em.Core.Application.CQRS.Tickets.Commands;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class UpdateTicketApprovalWorkflowCommandHandler : IRequestHandler<UpdateTicketApprovalWorkflowCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateTicketApprovalWorkflowCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
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

            var cached = DtoMapper.Map<TicketApprovalWorkflow, GetByIdTicketApprovalWorkflowDto>(entity);
            await _cache.SetAsync($"TicketApprovalWorkflow:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
