using MediatR;
using Em.Core.Application.CQRS.Queries.Notifications;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Domain.Entities.Notifications;

namespace Em.Core.Application.CQRS.Handlers.Queries.Notifications
{
    public class GetAllNotificationDeliveryQueryHandler : IRequestHandler<GetAllNotificationDeliveryQuery, IReadOnlyList<GetAllNotificationDeliveryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllNotificationDeliveryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllNotificationDeliveryDto>> Handle(GetAllNotificationDeliveryQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.NotificationDeliveryRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<NotificationDelivery, GetAllNotificationDeliveryDto>)
                .ToList();
}
}
}
