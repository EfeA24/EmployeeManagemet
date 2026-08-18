using Em.Core.Application.CQRS.Tickets.Commands;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
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

            DtoMapper.MapTo(request.UpdateApprovalDelegationDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.ApprovalDelegationRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<ApprovalDelegation, GetByIdApprovalDelegationDto>(entity);
            await _cache.SetAsync($"ApprovalDelegation:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
