using Em.Core.Application.CQRS.Tickets.Commands;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class UpdateGeneralTicketCommandHandler : IRequestHandler<UpdateGeneralTicketCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateGeneralTicketCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateGeneralTicketCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.GeneralTicketRepository.GetByIdAsync(request.UpdateGeneralTicketDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateGeneralTicketDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.GeneralTicketRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<GeneralTicket, GetByIdGeneralTicketDto>(entity);
            await _cache.SetAsync($"GeneralTicket:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
