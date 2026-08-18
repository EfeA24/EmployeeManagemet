using Em.Core.Application.CQRS.Tickets.Commands;
using Em.Core.Application.DTOs.CreateDtos.Tickets;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class CreateTicketAttachmentCommandHandler : IRequestHandler<CreateTicketAttachmentCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateTicketAttachmentCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateTicketAttachmentCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateTicketAttachmentDto, TicketAttachment>(request.CreateTicketAttachmentDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.TicketAttachmentRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<TicketAttachment, GetByIdTicketAttachmentDto>(entity);
            await _cache.SetAsync($"TicketAttachment:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
