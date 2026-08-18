using Em.Core.Application.CQRS.Commands.Identity;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Commands.Identity
{
    public class UpdateUserPermissionCommandHandler : IRequestHandler<UpdateUserPermissionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateUserPermissionCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateUserPermissionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.UserPermissionRepository.GetByIdAsync(request.UpdateUserPermissionDto.Id, cancellationToken);
            if (entity is null)
                return;

            request.UpdateUserPermissionDto.MapTo(entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.UserPermissionRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = entity.ToGetByIdDto();
            await _cache.SetAsync($"UserPermission:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
