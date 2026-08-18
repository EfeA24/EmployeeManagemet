using Em.Core.Application.CQRS.Notifications.Commands;
using Em.Core.Application.DTOs.CreateDtos.Notifications;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Notifications;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Commands
{
    public class CreateDeviceTokenCommandHandler : IRequestHandler<CreateDeviceTokenCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateDeviceTokenCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateDeviceTokenCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateDeviceTokenDto, DeviceToken>(request.CreateDeviceTokenDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.DeviceTokenRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<DeviceToken, GetByIdDeviceTokenDto>(entity);
            await _cache.SetAsync($"DeviceToken:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
