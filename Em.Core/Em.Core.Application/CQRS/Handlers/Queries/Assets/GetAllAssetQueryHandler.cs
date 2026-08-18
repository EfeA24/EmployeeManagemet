using MediatR;
using Em.Core.Application.CQRS.Queries.Assets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Assets;
using Em.Core.Domain.Entities.Assets;

namespace Em.Core.Application.CQRS.Handlers.Queries.Assets
{
    public class GetAllAssetQueryHandler : IRequestHandler<GetAllAssetQuery, IReadOnlyList<GetAllAssetDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAssetQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllAssetDto>> Handle(GetAllAssetQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.AssetRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<Asset, GetAllAssetDto>)
                .ToList();
}
}
}
