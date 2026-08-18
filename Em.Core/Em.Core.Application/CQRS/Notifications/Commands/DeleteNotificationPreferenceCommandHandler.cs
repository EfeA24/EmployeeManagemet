using Em.Core.Application.CQRS.Notifications.Commands;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Commands
{
    public class DeleteNotificationPreferenceCommandHandler : IRequestHandler<DeleteNotificationPreferenceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public DeleteNotificationPreferenceCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(DeleteNotificationPreferenceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.NotificationPreferenceRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.NotificationPreferenceRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _cache.RemoveAsync($"NotificationPreference:{request.Id}", cancellationToken);
        }
    }
}
