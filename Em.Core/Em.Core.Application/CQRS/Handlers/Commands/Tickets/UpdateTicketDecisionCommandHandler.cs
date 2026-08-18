using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
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

            request.UpdateTicketDecisionDto.MapTo(entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.TicketDecisionRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = entity.ToGetByIdDto();
            await _cache.SetAsync($"TicketDecision:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
