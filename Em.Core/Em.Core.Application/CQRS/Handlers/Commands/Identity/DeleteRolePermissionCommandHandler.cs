using MediatR;
using Em.Core.Application.CQRS.Commands.Identity;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Identity
{
    public class DeleteRolePermissionCommandHandler : IRequestHandler<DeleteRolePermissionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRolePermissionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteRolePermissionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.RolePermissionRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.RolePermissionRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
