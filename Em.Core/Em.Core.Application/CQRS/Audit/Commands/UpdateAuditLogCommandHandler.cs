using Em.Core.Application.CQRS.Audit.Commands;
using Em.Core.Application.DTOs.ReadDtos.Audit;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Audit;
using MediatR;

namespace Em.Core.Application.CQRS.Audit.Commands
{
    public class UpdateAuditLogCommandHandler : IRequestHandler<UpdateAuditLogCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateAuditLogCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateAuditLogCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AuditLogRepository.GetByIdAsync(request.UpdateAuditLogDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateAuditLogDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AuditLogRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<AuditLog, GetByIdAuditLogDto>(entity);
            await _cache.SetAsync($"AuditLog:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
