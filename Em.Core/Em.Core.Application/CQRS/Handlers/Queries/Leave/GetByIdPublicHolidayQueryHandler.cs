using MediatR;
using Em.Core.Application.CQRS.Queries.Leave;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Leave;
using Em.Core.Domain.Entities.Leave;

namespace Em.Core.Application.CQRS.Handlers.Queries.Leave
{
    public class GetByIdPublicHolidayQueryHandler : IRequestHandler<GetByIdPublicHolidayQuery, GetByIdPublicHolidayDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdPublicHolidayQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdPublicHolidayDto?> Handle(GetByIdPublicHolidayQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.PublicHolidayRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<PublicHoliday, GetByIdPublicHolidayDto>(entity);
}
}
}
