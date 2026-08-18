using MediatR;
using Em.Core.Application.CQRS.Queries.Organization;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Domain.Entities.Organization;

namespace Em.Core.Application.CQRS.Handlers.Queries.Organization
{
    public class GetAllCompanyQueryHandler : IRequestHandler<GetAllCompanyQuery, IReadOnlyList<GetAllCompanyDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCompanyQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllCompanyDto>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.CompanyRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<Company, GetAllCompanyDto>)
                .ToList();
}
}
}
