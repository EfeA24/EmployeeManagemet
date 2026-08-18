using Em.Core.Application.CQRS.Tickets.Commands;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class UpdateTicketAttachmentCommandHandler : IRequestHandler<UpdateTicketAttachmentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateTicketAttachmentCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateTicketAttachmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TicketAttachmentRepository.GetByIdAsync(request.UpdateTicketAttachmentDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateTicketAttachmentDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.TicketAttachmentRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<TicketAttachment, GetByIdTicketAttachmentDto>(entity);
            await _cache.SetAsync($"TicketAttachment:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
