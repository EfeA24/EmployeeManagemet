using Em.Core.Application.CQRS.Leave.Queries;
using Em.Core.Application.DTOs.ReadDtos.Leave;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Leave;
using MediatR;

namespace Em.Core.Application.CQRS.Leave.Queries
{
    public class GetByIdPublicHolidayQueryHandler : IRequestHandler<GetByIdPublicHolidayQuery, GetByIdPublicHolidayDto?>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetByIdPublicHolidayQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<GetByIdPublicHolidayDto?> Handle(GetByIdPublicHolidayQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dapperQuery.GetByIdAsync<PublicHoliday>(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<PublicHoliday, GetByIdPublicHolidayDto>(entity);
        }
    }
}
