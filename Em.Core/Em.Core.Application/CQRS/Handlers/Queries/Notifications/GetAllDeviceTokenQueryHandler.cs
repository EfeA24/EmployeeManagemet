using MediatR;
using Em.Core.Application.CQRS.Queries.Notifications;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Domain.Entities.Notifications;

namespace Em.Core.Application.CQRS.Handlers.Queries.Notifications
{
    public class GetAllDeviceTokenQueryHandler : IRequestHandler<GetAllDeviceTokenQuery, IReadOnlyList<GetAllDeviceTokenDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDeviceTokenQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllDeviceTokenDto>> Handle(GetAllDeviceTokenQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.DeviceTokenRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<DeviceToken, GetAllDeviceTokenDto>)
                .ToList();
}
}
}
