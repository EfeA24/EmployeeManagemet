using MediatR;
using Em.Core.Application.CQRS.Commands.Assets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.CreateDtos.Assets;
using Em.Core.Domain.Entities.Assets;

namespace Em.Core.Application.CQRS.Handlers.Commands.Assets
{
    public class CreateAssetAssignmentCommandHandler : IRequestHandler<CreateAssetAssignmentCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAssetAssignmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateAssetAssignmentCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateAssetAssignmentDto, AssetAssignment>(request.CreateAssetAssignmentDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AssetAssigmentRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
}
}
}
