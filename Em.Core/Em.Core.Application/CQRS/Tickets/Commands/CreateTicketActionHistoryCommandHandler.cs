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
    public class CreateTicketActionHistoryCommandHandler : IRequestHandler<CreateTicketActionHistoryCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateTicketActionHistoryCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateTicketActionHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateTicketActionHistoryDto, TicketActionHistory>(request.CreateTicketActionHistoryDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.TicketActionHistoryRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<TicketActionHistory, GetByIdTicketActionHistoryDto>(entity);
            await _cache.SetAsync($"TicketActionHistory:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
