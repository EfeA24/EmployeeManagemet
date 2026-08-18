using MediatR;
using Em.Core.Application.CQRS.Queries.Notifications;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Domain.Entities.Notifications;

namespace Em.Core.Application.CQRS.Handlers.Queries.Notifications
{
    public class GetAllNotificationPreferenceQueryHandler : IRequestHandler<GetAllNotificationPreferenceQuery, IReadOnlyList<GetAllNotificationPreferenceDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllNotificationPreferenceQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllNotificationPreferenceDto>> Handle(GetAllNotificationPreferenceQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.NotificationPreferenceRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<NotificationPreference, GetAllNotificationPreferenceDto>)
                .ToList();
}
}
}
