using MediatR;
using Em.Core.Application.CQRS.Commands.Notifications;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Notifications;

namespace Em.Core.Application.CQRS.Handlers.Commands.Notifications
{
    public class UpdateDeviceTokenCommandHandler : IRequestHandler<UpdateDeviceTokenCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDeviceTokenCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateDeviceTokenCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.DeviceTokenRepository.GetByIdAsync(request.UpdateDeviceTokenDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateDeviceTokenDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.DeviceTokenRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
