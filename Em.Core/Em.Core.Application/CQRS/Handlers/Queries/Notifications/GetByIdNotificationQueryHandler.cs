using MediatR;
using Em.Core.Application.CQRS.Queries.Notifications;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Domain.Entities.Notifications;

namespace Em.Core.Application.CQRS.Handlers.Queries.Notifications
{
    public class GetByIdNotificationQueryHandler : IRequestHandler<GetByIdNotificationQuery, GetByIdNotificationDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdNotificationQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdNotificationDto?> Handle(GetByIdNotificationQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.NotificationRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<Notification, GetByIdNotificationDto>(entity);
}
}
}
