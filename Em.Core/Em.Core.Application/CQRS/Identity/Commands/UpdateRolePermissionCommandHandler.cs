using Em.Core.Application.CQRS.Identity.Commands;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
{
    public class UpdateRolePermissionCommandHandler : IRequestHandler<UpdateRolePermissionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateRolePermissionCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateRolePermissionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.RolePermissionRepository.GetByIdAsync(request.UpdateRolePermissionDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateRolePermissionDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.RolePermissionRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<RolePermission, GetByIdRolePermissionDto>(entity);
            await _cache.SetAsync($"RolePermission:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
