using Em.Core.Application.CQRS.Identity.Commands;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
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

            DtoMapper.MapTo(request.UpdateUserPermissionDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.UserPermissionRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<UserPermission, GetByIdUserPermissionDto>(entity);
            await _cache.SetAsync($"UserPermission:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
