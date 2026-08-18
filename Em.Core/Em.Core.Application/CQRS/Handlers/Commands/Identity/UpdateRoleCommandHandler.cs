using MediatR;
using Em.Core.Application.CQRS.Commands.Identity;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Identity;

namespace Em.Core.Application.CQRS.Handlers.Commands.Identity
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.RoleRepository.GetByIdAsync(request.UpdateRoleDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateRoleDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.RoleRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
