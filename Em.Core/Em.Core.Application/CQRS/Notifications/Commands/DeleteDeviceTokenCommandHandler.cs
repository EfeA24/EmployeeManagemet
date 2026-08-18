using Em.Core.Application.CQRS.Notifications.Commands;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using MediatR;

namespace Em.Core.Application.CQRS.Notifications.Commands
{
    public class DeleteDeviceTokenCommandHandler : IRequestHandler<DeleteDeviceTokenCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public DeleteDeviceTokenCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(DeleteDeviceTokenCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.DeviceTokenRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.DeviceTokenRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _cache.RemoveAsync($"DeviceToken:{request.Id}", cancellationToken);
        }
    }
}
