using MediatR;
using Em.Core.Application.CQRS.Queries.Notifications;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Domain.Entities.Notifications;

namespace Em.Core.Application.CQRS.Handlers.Queries.Notifications
{
    public class GetByIdNotificationDeliveryQueryHandler : IRequestHandler<GetByIdNotificationDeliveryQuery, GetByIdNotificationDeliveryDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdNotificationDeliveryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdNotificationDeliveryDto?> Handle(GetByIdNotificationDeliveryQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.NotificationDeliveryRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<NotificationDelivery, GetByIdNotificationDeliveryDto>(entity);
}
}
}
