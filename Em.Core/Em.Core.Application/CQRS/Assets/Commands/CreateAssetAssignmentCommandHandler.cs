using Em.Core.Application.CQRS.Assets.Commands;
using Em.Core.Application.DTOs.CreateDtos.Assets;
using Em.Core.Application.DTOs.ReadDtos.Assets;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Assets;
using MediatR;

namespace Em.Core.Application.CQRS.Assets.Commands
{
    public class CreateAssetAssignmentCommandHandler : IRequestHandler<CreateAssetAssignmentCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateAssetAssignmentCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateAssetAssignmentCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateAssetAssignmentDto, AssetAssignment>(request.CreateAssetAssignmentDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AssetAssigmentRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<AssetAssignment, GetByIdAssetAssignmentDto>(entity);
            await _cache.SetAsync($"AssetAssignment:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
