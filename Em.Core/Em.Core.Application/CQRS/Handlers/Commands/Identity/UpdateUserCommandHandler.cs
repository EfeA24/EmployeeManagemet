using MediatR;
using Em.Core.Application.CQRS.Commands.Identity;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Identity;

namespace Em.Core.Application.CQRS.Handlers.Commands.Identity
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.UserRepository.GetByIdAsync(request.UpdateUserDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateUserDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.UserRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
