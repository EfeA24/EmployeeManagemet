using MediatR;
using Em.Core.Application.CQRS.Queries.Notifications;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Domain.Entities.Notifications;

namespace Em.Core.Application.CQRS.Handlers.Queries.Notifications
{
    public class GetAllNotificationQueryHandler : IRequestHandler<GetAllNotificationQuery, IReadOnlyList<GetAllNotificationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllNotificationQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllNotificationDto>> Handle(GetAllNotificationQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.NotificationRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<Notification, GetAllNotificationDto>)
                .ToList();
}
}
}
