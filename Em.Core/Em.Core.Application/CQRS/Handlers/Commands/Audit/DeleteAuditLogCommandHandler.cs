using MediatR;
using Em.Core.Application.CQRS.Commands.Audit;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Audit
{
    public class DeleteAuditLogCommandHandler : IRequestHandler<DeleteAuditLogCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAuditLogCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteAuditLogCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AuditLogRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.AuditLogRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
