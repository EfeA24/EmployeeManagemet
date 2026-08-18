using Em.Core.Application.CQRS.Leave.Queries;
using Em.Core.Application.DTOs.ReadDtos.Leave;
using Em.Core.Application.Interfaces.Dapper;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Leave;
using MediatR;

namespace Em.Core.Application.CQRS.Leave.Queries
{
    public class GetAllPublicHolidayQueryHandler : IRequestHandler<GetAllPublicHolidayQuery, IReadOnlyList<GetAllPublicHolidayDto>>
    {
        private readonly IDapperQuery _dapperQuery;

        public GetAllPublicHolidayQueryHandler(IDapperQuery dapperQuery)
        {
            _dapperQuery = dapperQuery;
        }

        public async Task<IReadOnlyList<GetAllPublicHolidayDto>> Handle(GetAllPublicHolidayQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dapperQuery.GetAllAsync<PublicHoliday>(cancellationToken);

            return entities
                .Select(DtoMapper.Map<PublicHoliday, GetAllPublicHolidayDto>)
                .ToList();
        }
    }
}
