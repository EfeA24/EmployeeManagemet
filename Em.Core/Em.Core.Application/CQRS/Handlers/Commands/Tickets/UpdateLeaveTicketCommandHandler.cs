using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class UpdateLeaveTicketCommandHandler : IRequestHandler<UpdateLeaveTicketCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateLeaveTicketCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateLeaveTicketCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.LeaveTicketRepository.GetByIdAsync(request.UpdateLeaveTicketDto.Id, cancellationToken);
            if (entity is null)
                return;

            request.UpdateLeaveTicketDto.MapTo(entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.LeaveTicketRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = entity.ToGetByIdDto();
            await _cache.SetAsync($"LeaveTicket:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
