using Em.Core.Application.CQRS.Tickets.Commands;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class DeleteTicketAttachmentCommandHandler : IRequestHandler<DeleteTicketAttachmentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public DeleteTicketAttachmentCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(DeleteTicketAttachmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketAttachmentRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.TicketAttachmentRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _cache.RemoveAsync($"TicketAttachment:{request.Id}", cancellationToken);
        }
    }
}
