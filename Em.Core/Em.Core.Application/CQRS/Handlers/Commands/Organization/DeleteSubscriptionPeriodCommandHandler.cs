using MediatR;
using Em.Core.Application.CQRS.Commands.Organization;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Organization
{
    public class DeleteSubscriptionPeriodCommandHandler : IRequestHandler<DeleteSubscriptionPeriodCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSubscriptionPeriodCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteSubscriptionPeriodCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.SubscriptionPeriodRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.SubscriptionPeriodRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
