using MediatR;
using Em.Core.Application.CQRS.Queries.Exports;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Exports;
using Em.Core.Domain.Entities.Exports;

namespace Em.Core.Application.CQRS.Handlers.Queries.Exports
{
    public class GetAllDataExportRequestQueryHandler : IRequestHandler<GetAllDataExportRequestQuery, IReadOnlyList<GetAllDataExportRequestDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDataExportRequestQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllDataExportRequestDto>> Handle(GetAllDataExportRequestQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.DataExportRequestRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<DataExportRequest, GetAllDataExportRequestDto>)
                .ToList();
}
}
}
