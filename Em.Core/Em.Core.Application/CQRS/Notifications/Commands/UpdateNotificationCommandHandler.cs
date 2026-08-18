using Em.Core.Application.CQRS.Notifications.Commands;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Commands
{
    public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateNotificationCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.NotificationRepository.GetByIdAsync(request.UpdateNotificationDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateNotificationDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.NotificationRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<Notification, GetByIdNotificationDto>(entity);
            await _cache.SetAsync($"Notification:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
