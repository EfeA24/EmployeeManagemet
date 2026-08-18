using MediatR;
using Em.Core.Application.CQRS.Commands.Notifications;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Notifications;

namespace Em.Core.Application.CQRS.Handlers.Commands.Notifications
{
    public class UpdateNotificationPreferenceCommandHandler : IRequestHandler<UpdateNotificationPreferenceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateNotificationPreferenceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateNotificationPreferenceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.NotificationPreferenceRepository.GetByIdAsync(request.UpdateNotificationPreferenceDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateNotificationPreferenceDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.NotificationPreferenceRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
