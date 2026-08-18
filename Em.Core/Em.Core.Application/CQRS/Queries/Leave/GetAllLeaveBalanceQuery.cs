using Em.Core.Application.DTOs.ReadDtos.Leave;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Leave
{
    public class GetAllLeaveBalanceQuery : IRequest<IReadOnlyList<GetAllLeaveBalanceDto>>
    {
    }
}
