using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class UpdateTicketActionHistoryCommandHandler : IRequestHandler<UpdateTicketActionHistoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateTicketActionHistoryCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateTicketActionHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketActionHistoryRepository.GetByIdAsync(request.UpdateTicketActionHistoryDto.Id, cancellationToken);
            if (entity is null)
                return;

            request.UpdateTicketActionHistoryDto.MapTo(entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.TicketActionHistoryRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = entity.ToGetByIdDto();
            await _cache.SetAsync($"TicketActionHistory:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
