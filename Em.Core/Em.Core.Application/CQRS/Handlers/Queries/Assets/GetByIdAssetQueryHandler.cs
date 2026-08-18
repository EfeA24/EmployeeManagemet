using MediatR;
using Em.Core.Application.CQRS.Queries.Assets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Assets;
using Em.Core.Domain.Entities.Assets;

namespace Em.Core.Application.CQRS.Handlers.Queries.Assets
{
    public class GetByIdAssetQueryHandler : IRequestHandler<GetByIdAssetQuery, GetByIdAssetDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdAssetQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdAssetDto?> Handle(GetByIdAssetQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AssetRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<Asset, GetByIdAssetDto>(entity);
}
}
}
