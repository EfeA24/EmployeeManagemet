using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class CreateApprovalDelegationCommandHandler : IRequestHandler<CreateApprovalDelegationCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateApprovalDelegationCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateApprovalDelegationCommand request, CancellationToken cancellationToken)
        {
            var entity = request.CreateApprovalDelegationDto.ToEntity();
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.ApprovalDelegationRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = entity.ToGetByIdDto();
            await _cache.SetAsync($"ApprovalDelegation:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
