using Em.Core.Application.CQRS.Exports.Commands;
using Em.Core.Application.DTOs.CreateDtos.Exports;
using Em.Core.Application.DTOs.ReadDtos.Exports;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Exports;
using MediatR;

namespace Em.Core.Application.CQRS.Exports.Commands
{
    public class CreateDataExportRequestCommandHandler : IRequestHandler<CreateDataExportRequestCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateDataExportRequestCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateDataExportRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateDataExportRequestDto, DataExportRequest>(request.CreateDataExportRequestDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.DataExportRequestRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<DataExportRequest, GetByIdDataExportRequestDto>(entity);
            await _cache.SetAsync($"DataExportRequest:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
