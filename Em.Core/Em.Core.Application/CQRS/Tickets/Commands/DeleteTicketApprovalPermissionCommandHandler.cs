using Em.Core.Application.CQRS.Tickets.Commands;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class DeleteTicketApprovalPermissionCommandHandler : IRequestHandler<DeleteTicketApprovalPermissionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public DeleteTicketApprovalPermissionCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(DeleteTicketApprovalPermissionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketApprovalPermissionRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.TicketApprovalPermissionRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _cache.RemoveAsync($"TicketApprovalPermission:{request.Id}", cancellationToken);
        }
    }
}
