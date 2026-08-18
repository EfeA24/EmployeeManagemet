using Em.Core.Application.CQRS.Identity.Commands;
using Em.Core.Application.DTOs.CreateDtos.Identity;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Identity;
using MediatR;

namespace Em.Core.Application.CQRS.Identity.Commands
{
    public class CreateUserPermissionCommandHandler : IRequestHandler<CreateUserPermissionCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateUserPermissionCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateUserPermissionCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateUserPermissionDto, UserPermission>(request.CreateUserPermissionDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.UserPermissionRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<UserPermission, GetByIdUserPermissionDto>(entity);
            await _cache.SetAsync($"UserPermission:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
