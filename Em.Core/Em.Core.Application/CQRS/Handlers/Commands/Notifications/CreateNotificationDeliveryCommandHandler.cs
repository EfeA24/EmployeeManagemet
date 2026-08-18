using MediatR;
using Em.Core.Application.CQRS.Commands.Notifications;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.CreateDtos.Notifications;
using Em.Core.Domain.Entities.Notifications;

namespace Em.Core.Application.CQRS.Handlers.Commands.Notifications
{
    public class CreateNotificationDeliveryCommandHandler : IRequestHandler<CreateNotificationDeliveryCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateNotificationDeliveryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateNotificationDeliveryCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateNotificationDeliveryDto, NotificationDelivery>(request.CreateNotificationDeliveryDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.NotificationDeliveryRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
}
}
}
