using Em.Core.Application.CQRS.Tickets.Commands;
using Em.Core.Application.DTOs.CreateDtos.Tickets;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class CreateTicketApprovalWorkflowStageCommandHandler : IRequestHandler<CreateTicketApprovalWorkflowStageCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateTicketApprovalWorkflowStageCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateTicketApprovalWorkflowStageCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateTicketApprovalWorkflowStageDto, TicketApprovalWorkflowStage>(request.CreateTicketApprovalWorkflowStageDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.TicketApprovalWorkflowStageRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<TicketApprovalWorkflowStage, GetByIdTicketApprovalWorkflowStageDto>(entity);
            await _cache.SetAsync($"TicketApprovalWorkflowStage:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
