using MediatR;
using Em.Core.Application.CQRS.Commands.Organization;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Organization;

namespace Em.Core.Application.CQRS.Handlers.Commands.Organization
{
    public class UpdateSubscriptionPeriodCommandHandler : IRequestHandler<UpdateSubscriptionPeriodCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSubscriptionPeriodCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateSubscriptionPeriodCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.SubscriptionPeriodRepository.GetByIdAsync(request.UpdateSubscriptionPeriodDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateSubscriptionPeriodDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.SubscriptionPeriodRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
