using MediatR;
using Em.Core.Application.CQRS.Commands.Organization;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.CreateDtos.Organization;
using Em.Core.Domain.Entities.Organization;

namespace Em.Core.Application.CQRS.Handlers.Commands.Organization
{
    public class CreateSubscriptionPeriodCommandHandler : IRequestHandler<CreateSubscriptionPeriodCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSubscriptionPeriodCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateSubscriptionPeriodCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateSubscriptionPeriodDto, SubscriptionPeriod>(request.CreateSubscriptionPeriodDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.SubscriptionPeriodRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
}
}
}
