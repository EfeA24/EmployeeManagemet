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
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateNotificationCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateNotificationDto, Notification>(request.CreateNotificationDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.NotificationRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<Notification, GetByIdNotificationDto>(entity);
            await _cache.SetAsync($"Notification:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
