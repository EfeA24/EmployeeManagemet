using MediatR;
using Em.Core.Application.CQRS.Commands.Audit;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Audit;

namespace Em.Core.Application.CQRS.Handlers.Commands.Audit
{
    public class UpdateAuditLogCommandHandler : IRequestHandler<UpdateAuditLogCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAuditLogCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
}
}
}
