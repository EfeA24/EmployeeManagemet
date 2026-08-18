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
    public class CreateGeneralTicketCommandHandler : IRequestHandler<CreateGeneralTicketCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateGeneralTicketCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateGeneralTicketCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateGeneralTicketDto, GeneralTicket>(request.CreateGeneralTicketDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.GeneralTicketRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<GeneralTicket, GetByIdGeneralTicketDto>(entity);
            await _cache.SetAsync($"GeneralTicket:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
