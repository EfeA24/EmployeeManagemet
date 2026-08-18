using MediatR;
using Em.Core.Application.CQRS.Commands.Exports;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Exports;

namespace Em.Core.Application.CQRS.Handlers.Commands.Exports
{
    public class UpdateDataExportRequestCommandHandler : IRequestHandler<UpdateDataExportRequestCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDataExportRequestCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateDataExportRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.DataExportRequestRepository.GetByIdAsync(request.UpdateDataExportRequestDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateDataExportRequestDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.DataExportRequestRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
