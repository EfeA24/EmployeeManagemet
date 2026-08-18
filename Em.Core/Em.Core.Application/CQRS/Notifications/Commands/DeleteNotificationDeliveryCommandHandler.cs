using Em.Core.Application.CQRS.Notifications.Commands;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Commands
{
    public class DeleteNotificationDeliveryCommandHandler : IRequestHandler<DeleteNotificationDeliveryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public DeleteNotificationDeliveryCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(DeleteNotificationDeliveryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.NotificationDeliveryRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.NotificationDeliveryRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _cache.RemoveAsync($"NotificationDelivery:{request.Id}", cancellationToken);
        }
    }
}
