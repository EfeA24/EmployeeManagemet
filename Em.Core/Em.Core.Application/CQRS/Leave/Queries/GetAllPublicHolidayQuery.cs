using Em.Core.Application.DTOs.ReadDtos.Leave;
using MediatR;

namespace Em.Core.Application.CQRS.Leave.Queries
{
    public class GetAllPublicHolidayQuery : IRequest<IReadOnlyList<GetAllPublicHolidayDto>>
    {
    }
}
