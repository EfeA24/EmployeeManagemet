using MediatR;
using Em.Core.Application.CQRS.Queries.Leave;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Leave;
using Em.Core.Domain.Entities.Leave;

namespace Em.Core.Application.CQRS.Handlers.Queries.Leave
{
    public class GetAllPublicHolidayQueryHandler : IRequestHandler<GetAllPublicHolidayQuery, IReadOnlyList<GetAllPublicHolidayDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPublicHolidayQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllPublicHolidayDto>> Handle(GetAllPublicHolidayQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.PublicHolidayRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<PublicHoliday, GetAllPublicHolidayDto>)
                .ToList();
}
}
}
