using MediatR;
using Em.Core.Application.CQRS.Commands.Notifications;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Notifications
{
    public class DeleteDeviceTokenCommandHandler : IRequestHandler<DeleteDeviceTokenCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDeviceTokenCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteDeviceTokenCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.DeviceTokenRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.DeviceTokenRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
