using MediatR;
using Em.Core.Application.CQRS.Commands.Notifications;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Notifications;

namespace Em.Core.Application.CQRS.Handlers.Commands.Notifications
{
    public class UpdateNotificationDeliveryCommandHandler : IRequestHandler<UpdateNotificationDeliveryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateNotificationDeliveryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateNotificationDeliveryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.NotificationDeliveryRepository.GetByIdAsync(request.UpdateNotificationDeliveryDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateNotificationDeliveryDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.NotificationDeliveryRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
