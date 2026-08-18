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
    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateUserRoleCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateUserRoleDto, UserRole>(request.CreateUserRoleDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.UserRoleRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<UserRole, GetByIdUserRoleDto>(entity);
            await _cache.SetAsync($"UserRole:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
