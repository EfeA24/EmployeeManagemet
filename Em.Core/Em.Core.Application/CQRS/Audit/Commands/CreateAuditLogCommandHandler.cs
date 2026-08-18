using Em.Core.Application.CQRS.Audit.Commands;
using Em.Core.Application.DTOs.CreateDtos.Audit;
using Em.Core.Application.DTOs.ReadDtos.Audit;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Audit;
using MediatR;

namespace Em.Core.Application.CQRS.Audit.Commands
{
    public class CreateAuditLogCommandHandler : IRequestHandler<CreateAuditLogCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateAuditLogCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateAuditLogCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateAuditLogDto, AuditLog>(request.CreateAuditLogDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AuditLogRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<AuditLog, GetByIdAuditLogDto>(entity);
            await _cache.SetAsync($"AuditLog:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
