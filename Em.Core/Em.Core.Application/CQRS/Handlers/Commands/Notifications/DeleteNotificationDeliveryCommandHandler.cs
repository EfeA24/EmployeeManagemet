using MediatR;
using Em.Core.Application.CQRS.Commands.Notifications;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Notifications
{
    public class DeleteNotificationDeliveryCommandHandler : IRequestHandler<DeleteNotificationDeliveryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteNotificationDeliveryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteNotificationDeliveryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.NotificationDeliveryRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.NotificationDeliveryRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
