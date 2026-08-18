using MediatR;
using Em.Core.Application.CQRS.Queries.Assets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Assets;
using Em.Core.Domain.Entities.Assets;

namespace Em.Core.Application.CQRS.Handlers.Queries.Assets
{
    public class GetByIdAssetAssignmentQueryHandler : IRequestHandler<GetByIdAssetAssignmentQuery, GetByIdAssetAssignmentDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdAssetAssignmentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdAssetAssignmentDto?> Handle(GetByIdAssetAssignmentQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AssetAssigmentRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<AssetAssignment, GetByIdAssetAssignmentDto>(entity);
}
}
}
