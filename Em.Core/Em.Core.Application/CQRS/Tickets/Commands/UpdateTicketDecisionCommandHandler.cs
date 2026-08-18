using Em.Core.Application.CQRS.Tickets.Commands;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class UpdateTicketDecisionCommandHandler : IRequestHandler<UpdateTicketDecisionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateTicketDecisionCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateTicketDecisionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketDecisionRepository.GetByIdAsync(request.UpdateTicketDecisionDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateTicketDecisionDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.TicketDecisionRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<TicketDecision, GetByIdTicketDecisionDto>(entity);
            await _cache.SetAsync($"TicketDecision:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
