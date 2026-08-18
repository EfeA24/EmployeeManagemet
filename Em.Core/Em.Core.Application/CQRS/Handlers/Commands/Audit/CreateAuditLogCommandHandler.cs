using MediatR;
using Em.Core.Application.CQRS.Commands.Audit;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.CreateDtos.Audit;
using Em.Core.Domain.Entities.Audit;

namespace Em.Core.Application.CQRS.Handlers.Commands.Audit
{
    public class CreateAuditLogCommandHandler : IRequestHandler<CreateAuditLogCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAuditLogCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateAuditLogCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateAuditLogDto, AuditLog>(request.CreateAuditLogDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AuditLogRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
}
}
}
