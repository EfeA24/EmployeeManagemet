using Em.Core.Application.CQRS.Commands.Audit;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Commands.Audit
{
    public class DeleteAuditLogCommandHandler : IRequestHandler<DeleteAuditLogCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public DeleteAuditLogCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(DeleteAuditLogCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AuditLogRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.AuditLogRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _cache.RemoveAsync($"AuditLog:{request.Id}", cancellationToken);
        }
    }
}
