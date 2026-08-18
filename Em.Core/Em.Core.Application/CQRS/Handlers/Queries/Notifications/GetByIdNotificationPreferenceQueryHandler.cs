using MediatR;
using Em.Core.Application.CQRS.Queries.Notifications;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Domain.Entities.Notifications;

namespace Em.Core.Application.CQRS.Handlers.Queries.Notifications
{
    public class GetByIdNotificationPreferenceQueryHandler : IRequestHandler<GetByIdNotificationPreferenceQuery, GetByIdNotificationPreferenceDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdNotificationPreferenceQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdNotificationPreferenceDto?> Handle(GetByIdNotificationPreferenceQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.NotificationPreferenceRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<NotificationPreference, GetByIdNotificationPreferenceDto>(entity);
}
}
}
