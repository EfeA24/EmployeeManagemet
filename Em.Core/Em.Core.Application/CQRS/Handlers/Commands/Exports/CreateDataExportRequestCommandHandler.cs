using MediatR;
using Em.Core.Application.CQRS.Commands.Exports;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.CreateDtos.Exports;
using Em.Core.Domain.Entities.Exports;

namespace Em.Core.Application.CQRS.Handlers.Commands.Exports
{
    public class CreateDataExportRequestCommandHandler : IRequestHandler<CreateDataExportRequestCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDataExportRequestCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateDataExportRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateDataExportRequestDto, DataExportRequest>(request.CreateDataExportRequestDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.DataExportRequestRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
}
}
}
