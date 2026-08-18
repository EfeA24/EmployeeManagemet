using MediatR;
using Em.Core.Application.CQRS.Commands.Assets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Assets;

namespace Em.Core.Application.CQRS.Handlers.Commands.Assets
{
    public class UpdateAssetCommandHandler : IRequestHandler<UpdateAssetCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAssetCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateAssetCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AssetRepository.GetByIdAsync(request.UpdateAssetDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateAssetDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AssetRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
