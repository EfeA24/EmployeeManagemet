using MediatR;
using Em.Core.Application.CQRS.Commands.Identity;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Identity;

namespace Em.Core.Application.CQRS.Handlers.Commands.Identity
{
    public class UpdateUserPermissionCommandHandler : IRequestHandler<UpdateUserPermissionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserPermissionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateUserPermissionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.UserPermissionRepository.GetByIdAsync(request.UpdateUserPermissionDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateUserPermissionDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.UserPermissionRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
