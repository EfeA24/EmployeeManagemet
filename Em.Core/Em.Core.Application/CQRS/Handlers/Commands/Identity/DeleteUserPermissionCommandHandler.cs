using MediatR;
using Em.Core.Application.CQRS.Commands.Identity;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Identity
{
    public class DeleteUserPermissionCommandHandler : IRequestHandler<DeleteUserPermissionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserPermissionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteUserPermissionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.UserPermissionRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.UserPermissionRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
