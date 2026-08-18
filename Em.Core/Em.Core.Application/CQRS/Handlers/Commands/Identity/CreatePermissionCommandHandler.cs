using MediatR;
using Em.Core.Application.CQRS.Commands.Identity;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.CreateDtos.Identity;
using Em.Core.Domain.Entities.Identity;

namespace Em.Core.Application.CQRS.Handlers.Commands.Identity
{
    public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePermissionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreatePermissionDto, Permission>(request.CreatePermissionDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.PermissionRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
}
}
}
