using Em.Core.Application.CQRS.Commands.Assets;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Assets;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Commands.Assets
{
    public class UpdateAssetAssignmentCommandHandler : IRequestHandler<UpdateAssetAssignmentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateAssetAssignmentCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateAssetAssignmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AssetAssigmentRepository.GetByIdAsync(request.UpdateAssetAssignmentDto.Id, cancellationToken);
            if (entity is null)
                return;

            request.UpdateAssetAssignmentDto.MapTo(entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AssetAssigmentRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = entity.ToGetByIdDto();
            await _cache.SetAsync($"AssetAssignment:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
