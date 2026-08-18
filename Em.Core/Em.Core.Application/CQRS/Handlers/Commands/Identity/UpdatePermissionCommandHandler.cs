using MediatR;
using Em.Core.Application.CQRS.Commands.Identity;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Identity;

namespace Em.Core.Application.CQRS.Handlers.Commands.Identity
{
    public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePermissionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.PermissionRepository.GetByIdAsync(request.UpdatePermissionDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdatePermissionDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.PermissionRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
