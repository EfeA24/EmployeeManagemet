using MediatR;
using Em.Core.Application.CQRS.Queries.Exports;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Exports;
using Em.Core.Domain.Entities.Exports;

namespace Em.Core.Application.CQRS.Handlers.Queries.Exports
{
    public class GetByIdDataExportRequestQueryHandler : IRequestHandler<GetByIdDataExportRequestQuery, GetByIdDataExportRequestDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdDataExportRequestQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdDataExportRequestDto?> Handle(GetByIdDataExportRequestQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.DataExportRequestRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<DataExportRequest, GetByIdDataExportRequestDto>(entity);
}
}
}
