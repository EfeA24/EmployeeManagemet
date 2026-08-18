using Em.Core.Application.CQRS.Exports.Commands;
using Em.Core.Application.DTOs.ReadDtos.Exports;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Exports;
using MediatR;

namespace Em.Core.Application.CQRS.Exports.Commands
{
    public class UpdateDataExportRequestCommandHandler : IRequestHandler<UpdateDataExportRequestCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateDataExportRequestCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
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

            var cached = DtoMapper.Map<DataExportRequest, GetByIdDataExportRequestDto>(entity);
            await _cache.SetAsync($"DataExportRequest:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
