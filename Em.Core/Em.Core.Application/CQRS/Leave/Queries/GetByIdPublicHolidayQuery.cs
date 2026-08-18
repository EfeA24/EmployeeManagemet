using Em.Core.Application.DTOs.ReadDtos.Leave;
using MediatR;

namespace Em.Core.Application.CQRS.Leave.Queries
{
    public class GetByIdPublicHolidayQuery : IRequest<GetByIdPublicHolidayDto?>
    {
        public Guid Id { get; set; }

        public GetByIdPublicHolidayQuery(Guid id)
        {
            Id = id;
        }
    }
}
