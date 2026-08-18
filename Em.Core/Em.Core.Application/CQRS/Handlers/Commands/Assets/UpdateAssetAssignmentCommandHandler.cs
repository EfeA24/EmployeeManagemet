using MediatR;
using Em.Core.Application.CQRS.Commands.Assets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Assets;

namespace Em.Core.Application.CQRS.Handlers.Commands.Assets
{
    public class UpdateAssetAssignmentCommandHandler : IRequestHandler<UpdateAssetAssignmentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAssetAssignmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateAssetAssignmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AssetAssigmentRepository.GetByIdAsync(request.UpdateAssetAssignmentDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateAssetAssignmentDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AssetAssigmentRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
