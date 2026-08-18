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
    public class CreateNotificationPreferenceCommandHandler : IRequestHandler<CreateNotificationPreferenceCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateNotificationPreferenceCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateNotificationPreferenceCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateNotificationPreferenceDto, NotificationPreference>(request.CreateNotificationPreferenceDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.NotificationPreferenceRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<NotificationPreference, GetByIdNotificationPreferenceDto>(entity);
            await _cache.SetAsync($"NotificationPreference:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
