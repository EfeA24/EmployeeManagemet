using MediatR;
using Em.Core.Application.CQRS.Commands.Notifications;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.CreateDtos.Notifications;
using Em.Core.Domain.Entities.Notifications;

namespace Em.Core.Application.CQRS.Handlers.Commands.Notifications
{
    public class CreateDeviceTokenCommandHandler : IRequestHandler<CreateDeviceTokenCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDeviceTokenCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateDeviceTokenCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateDeviceTokenDto, DeviceToken>(request.CreateDeviceTokenDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.DeviceTokenRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
}
}
}
