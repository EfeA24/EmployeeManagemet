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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateUserDto, User>(request.CreateUserDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.UserRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<User, GetByIdUserDto>(entity);
            await _cache.SetAsync($"User:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
