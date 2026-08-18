using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class UpdateAssetRequestTicketCommandHandler : IRequestHandler<UpdateAssetRequestTicketCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAssetRequestTicketCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateAssetRequestTicketCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AssetRequestTicketRepository.GetByIdAsync(request.UpdateAssetRequestTicketDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateAssetRequestTicketDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AssetRequestTicketRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
