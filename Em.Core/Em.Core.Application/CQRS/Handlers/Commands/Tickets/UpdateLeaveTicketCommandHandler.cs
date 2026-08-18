using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class UpdateLeaveTicketCommandHandler : IRequestHandler<UpdateLeaveTicketCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateLeaveTicketCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateLeaveTicketCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.LeaveTicketRepository.GetByIdAsync(request.UpdateLeaveTicketDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateLeaveTicketDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.LeaveTicketRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
