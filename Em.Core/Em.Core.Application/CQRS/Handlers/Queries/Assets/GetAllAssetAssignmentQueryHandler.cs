using MediatR;
using Em.Core.Application.CQRS.Queries.Assets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Assets;
using Em.Core.Domain.Entities.Assets;

namespace Em.Core.Application.CQRS.Handlers.Queries.Assets
{
    public class GetAllAssetAssignmentQueryHandler : IRequestHandler<GetAllAssetAssignmentQuery, IReadOnlyList<GetAllAssetAssignmentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAssetAssignmentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllAssetAssignmentDto>> Handle(GetAllAssetAssignmentQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.AssetAssigmentRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<AssetAssignment, GetAllAssetAssignmentDto>)
                .ToList();
}
}
}
