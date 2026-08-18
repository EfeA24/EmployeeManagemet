using Em.Core.Application.CQRS.Identity.Commands;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
{
    public class DeleteUserPermissionCommandHandler : IRequestHandler<DeleteUserPermissionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public DeleteUserPermissionCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(DeleteUserPermissionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.UserPermissionRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.UserPermissionRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _cache.RemoveAsync($"UserPermission:{request.Id}", cancellationToken);
        }
    }
}
