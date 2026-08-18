using MediatR;
using Em.Core.Application.CQRS.Commands.Notifications;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Notifications;

namespace Em.Core.Application.CQRS.Handlers.Commands.Notifications
{
    public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateNotificationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
}
}
}
