using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class UpdateAssetRequestTicketCommandHandler : IRequestHandler<UpdateAssetRequestTicketCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateAssetRequestTicketCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateAssetRequestTicketCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AssetRequestTicketRepository.GetByIdAsync(request.UpdateAssetRequestTicketDto.Id, cancellationToken);
            if (entity is null)
                return;

            request.UpdateAssetRequestTicketDto.MapTo(entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AssetRequestTicketRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = entity.ToGetByIdDto();
            await _cache.SetAsync($"AssetRequestTicket:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
