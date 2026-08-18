using Em.Core.Application.CQRS.Commands.Exports;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Exports;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Commands.Exports
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
            var entity = request.CreateDataExportRequestDto.ToEntity();
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.DataExportRequestRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = entity.ToGetByIdDto();
            await _cache.SetAsync($"DataExportRequest:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
