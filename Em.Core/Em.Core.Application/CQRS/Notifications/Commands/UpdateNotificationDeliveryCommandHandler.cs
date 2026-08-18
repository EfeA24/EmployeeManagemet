using Em.Core.Application.CQRS.Notifications.Commands;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Commands
{
    public class UpdateNotificationDeliveryCommandHandler : IRequestHandler<UpdateNotificationDeliveryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateNotificationDeliveryCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
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

            var cached = DtoMapper.Map<NotificationDelivery, GetByIdNotificationDeliveryDto>(entity);
            await _cache.SetAsync($"NotificationDelivery:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
