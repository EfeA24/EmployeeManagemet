using MediatR;
using Em.Core.Application.CQRS.Commands.Identity;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Identity;

namespace Em.Core.Application.CQRS.Handlers.Commands.Identity
{
    public class UpdateRolePermissionCommandHandler : IRequestHandler<UpdateRolePermissionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRolePermissionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
}
}
}
