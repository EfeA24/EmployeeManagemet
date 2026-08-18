using MediatR;
using Em.Core.Application.CQRS.Queries.Organization;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Domain.Entities.Organization;

namespace Em.Core.Application.CQRS.Handlers.Queries.Organization
{
    public class GetAllCompanySettingQueryHandler : IRequestHandler<GetAllCompanySettingQuery, IReadOnlyList<GetAllCompanySettingDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCompanySettingQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllCompanySettingDto>> Handle(GetAllCompanySettingQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.CompanySettingRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<CompanySetting, GetAllCompanySettingDto>)
                .ToList();
}
}
}
