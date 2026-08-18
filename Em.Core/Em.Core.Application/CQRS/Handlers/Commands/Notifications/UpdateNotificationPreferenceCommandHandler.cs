using Em.Core.Application.CQRS.Commands.Notifications;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Commands.Notifications
{
    public class UpdateNotificationPreferenceCommandHandler : IRequestHandler<UpdateNotificationPreferenceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateNotificationPreferenceCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateNotificationPreferenceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.NotificationPreferenceRepository.GetByIdAsync(request.UpdateNotificationPreferenceDto.Id, cancellationToken);
            if (entity is null)
                return;

            request.UpdateNotificationPreferenceDto.MapTo(entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.NotificationPreferenceRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = entity.ToGetByIdDto();
            await _cache.SetAsync($"NotificationPreference:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
