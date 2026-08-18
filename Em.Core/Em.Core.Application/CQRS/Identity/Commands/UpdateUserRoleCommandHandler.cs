using Em.Core.Application.CQRS.Identity.Commands;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
{
    public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateUserRoleCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.UserRoleRepository.GetByIdAsync(request.UpdateUserRoleDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateUserRoleDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.UserRoleRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<UserRole, GetByIdUserRoleDto>(entity);
            await _cache.SetAsync($"UserRole:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
