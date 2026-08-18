using Em.Core.Application.CQRS.Commands.Assets;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Assets;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Commands.Assets
{
    public class UpdateAssetCommandHandler : IRequestHandler<UpdateAssetCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateAssetCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateAssetCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AssetRepository.GetByIdAsync(request.UpdateAssetDto.Id, cancellationToken);
            if (entity is null)
                return;

            request.UpdateAssetDto.MapTo(entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AssetRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = entity.ToGetByIdDto();
            await _cache.SetAsync($"Asset:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
