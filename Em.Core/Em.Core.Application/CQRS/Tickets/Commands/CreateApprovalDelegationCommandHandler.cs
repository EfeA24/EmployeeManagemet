using Em.Core.Application.CQRS.Tickets.Commands;
using Em.Core.Application.DTOs.CreateDtos.Tickets;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
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
            var entity = DtoMapper.Map<CreateApprovalDelegationDto, ApprovalDelegation>(request.CreateApprovalDelegationDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.ApprovalDelegationRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<ApprovalDelegation, GetByIdApprovalDelegationDto>(entity);
            await _cache.SetAsync($"ApprovalDelegation:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
