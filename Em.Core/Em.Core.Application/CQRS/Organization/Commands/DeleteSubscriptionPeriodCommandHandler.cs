using Em.Core.Application.CQRS.Organization.Commands;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Commands
{
    public class DeleteSubscriptionPeriodCommandHandler : IRequestHandler<DeleteSubscriptionPeriodCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public DeleteSubscriptionPeriodCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(DeleteSubscriptionPeriodCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.SubscriptionPeriodRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.SubscriptionPeriodRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _cache.RemoveAsync($"SubscriptionPeriod:{request.Id}", cancellationToken);
        }
    }
}
