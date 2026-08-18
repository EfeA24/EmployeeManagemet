using MediatR;
using Em.Core.Application.CQRS.Commands.Assets;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Assets
{
    public class DeleteAssetAssignmentCommandHandler : IRequestHandler<DeleteAssetAssignmentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAssetAssignmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteAssetAssignmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AssetAssigmentRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.AssetAssigmentRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
