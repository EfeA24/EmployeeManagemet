using Em.Core.Application.CQRS.Identity.Commands;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
{
    public class DeletePermissionCommandHandler : IRequestHandler<DeletePermissionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public DeletePermissionCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.PermissionRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.PermissionRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _cache.RemoveAsync($"Permission:{request.Id}", cancellationToken);
        }
    }
}
