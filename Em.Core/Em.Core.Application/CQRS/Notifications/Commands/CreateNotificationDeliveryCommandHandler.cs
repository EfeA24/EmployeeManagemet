using Em.Core.Application.CQRS.Notifications.Commands;
using Em.Core.Application.DTOs.CreateDtos.Notifications;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Commands
{
    public class CreateNotificationDeliveryCommandHandler : IRequestHandler<CreateNotificationDeliveryCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateNotificationDeliveryCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateNotificationDeliveryCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateNotificationDeliveryDto, NotificationDelivery>(request.CreateNotificationDeliveryDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.NotificationDeliveryRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<NotificationDelivery, GetByIdNotificationDeliveryDto>(entity);
            await _cache.SetAsync($"NotificationDelivery:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
