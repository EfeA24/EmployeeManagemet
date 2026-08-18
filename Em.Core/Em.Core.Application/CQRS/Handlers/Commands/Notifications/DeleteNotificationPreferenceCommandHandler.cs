using MediatR;
using Em.Core.Application.CQRS.Commands.Notifications;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Notifications
{
    public class DeleteNotificationPreferenceCommandHandler : IRequestHandler<DeleteNotificationPreferenceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteNotificationPreferenceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteNotificationPreferenceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.NotificationPreferenceRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.NotificationPreferenceRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
