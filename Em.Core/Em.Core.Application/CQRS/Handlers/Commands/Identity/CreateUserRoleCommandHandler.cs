using MediatR;
using Em.Core.Application.CQRS.Commands.Identity;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.CreateDtos.Identity;
using Em.Core.Domain.Entities.Identity;

namespace Em.Core.Application.CQRS.Handlers.Commands.Identity
{
    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateUserRoleDto, UserRole>(request.CreateUserRoleDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.UserRoleRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
}
}
}
