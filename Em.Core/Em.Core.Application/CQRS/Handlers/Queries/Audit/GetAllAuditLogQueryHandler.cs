using MediatR;
using Em.Core.Application.CQRS.Queries.Audit;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Audit;
using Em.Core.Domain.Entities.Audit;

namespace Em.Core.Application.CQRS.Handlers.Queries.Audit
{
    public class GetAllAuditLogQueryHandler : IRequestHandler<GetAllAuditLogQuery, IReadOnlyList<GetAllAuditLogDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAuditLogQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllAuditLogDto>> Handle(GetAllAuditLogQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.AuditLogRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<AuditLog, GetAllAuditLogDto>)
                .ToList();
}
}
}
