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
    public class CreateAssetRequestTicketCommandHandler : IRequestHandler<CreateAssetRequestTicketCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateAssetRequestTicketCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateAssetRequestTicketCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateAssetRequestTicketDto, AssetRequestTicket>(request.CreateAssetRequestTicketDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AssetRequestTicketRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<AssetRequestTicket, GetByIdAssetRequestTicketDto>(entity);
            await _cache.SetAsync($"AssetRequestTicket:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
