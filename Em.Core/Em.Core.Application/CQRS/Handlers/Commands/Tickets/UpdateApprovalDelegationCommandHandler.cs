using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class UpdateApprovalDelegationCommandHandler : IRequestHandler<UpdateApprovalDelegationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateApprovalDelegationCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateApprovalDelegationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ApprovalDelegationRepository.GetByIdAsync(request.UpdateApprovalDelegationDto.Id, cancellationToken);
            if (entity is null)
                return;

            request.UpdateApprovalDelegationDto.MapTo(entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.ApprovalDelegationRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = entity.ToGetByIdDto();
            await _cache.SetAsync($"ApprovalDelegation:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
