using Em.Core.Application.CQRS.Identity.Commands;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateRoleCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.RoleRepository.GetByIdAsync(request.UpdateRoleDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateRoleDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.RoleRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<Role, GetByIdRoleDto>(entity);
            await _cache.SetAsync($"Role:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
