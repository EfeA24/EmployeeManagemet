using Em.Core.Application.CQRS.Notifications.Commands;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Commands
{
    public class UpdateDeviceTokenCommandHandler : IRequestHandler<UpdateDeviceTokenCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateDeviceTokenCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateDeviceTokenCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.DeviceTokenRepository.GetByIdAsync(request.UpdateDeviceTokenDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateDeviceTokenDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.DeviceTokenRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<DeviceToken, GetByIdDeviceTokenDto>(entity);
            await _cache.SetAsync($"DeviceToken:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
