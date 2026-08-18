using Em.Core.Application.CQRS.Commands.Audit;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Audit;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Commands.Audit
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
            var entity = request.CreateAuditLogDto.ToEntity();
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AuditLogRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = entity.ToGetByIdDto();
            await _cache.SetAsync($"AuditLog:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
