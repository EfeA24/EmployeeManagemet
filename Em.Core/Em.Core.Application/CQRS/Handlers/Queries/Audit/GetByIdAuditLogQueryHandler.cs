using MediatR;
using Em.Core.Application.CQRS.Queries.Audit;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Audit;
using Em.Core.Domain.Entities.Audit;

namespace Em.Core.Application.CQRS.Handlers.Queries.Audit
{
    public class GetByIdAuditLogQueryHandler : IRequestHandler<GetByIdAuditLogQuery, GetByIdAuditLogDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdAuditLogQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdAuditLogDto?> Handle(GetByIdAuditLogQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AuditLogRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<AuditLog, GetByIdAuditLogDto>(entity);
}
}
}
