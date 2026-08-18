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
    public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreatePermissionCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreatePermissionDto, Permission>(request.CreatePermissionDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.PermissionRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<Permission, GetByIdPermissionDto>(entity);
            await _cache.SetAsync($"Permission:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
