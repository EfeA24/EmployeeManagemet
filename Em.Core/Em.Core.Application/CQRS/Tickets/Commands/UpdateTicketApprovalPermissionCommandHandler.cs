using Em.Core.Application.CQRS.Tickets.Commands;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class UpdateTicketApprovalPermissionCommandHandler : IRequestHandler<UpdateTicketApprovalPermissionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateTicketApprovalPermissionCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateTicketApprovalPermissionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketApprovalPermissionRepository.GetByIdAsync(request.UpdateTicketApprovalPermissionDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateTicketApprovalPermissionDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.TicketApprovalPermissionRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<TicketApprovalPermission, GetByIdTicketApprovalPermissionDto>(entity);
            await _cache.SetAsync($"TicketApprovalPermission:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
