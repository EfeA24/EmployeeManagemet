using Em.Core.Application.CQRS.Commands.Organization;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Commands.Organization
{
    public class UpdateSubscriptionPeriodCommandHandler : IRequestHandler<UpdateSubscriptionPeriodCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateSubscriptionPeriodCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateSubscriptionPeriodCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.SubscriptionPeriodRepository.GetByIdAsync(request.UpdateSubscriptionPeriodDto.Id, cancellationToken);
            if (entity is null)
                return;

            request.UpdateSubscriptionPeriodDto.MapTo(entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.SubscriptionPeriodRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = entity.ToGetByIdDto();
            await _cache.SetAsync($"SubscriptionPeriod:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
