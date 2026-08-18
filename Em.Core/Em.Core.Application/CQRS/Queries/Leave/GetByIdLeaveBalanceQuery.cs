using Em.Core.Application.DTOs.ReadDtos.Leave;
using MediatR;

namespace Em.Core.Application.CQRS.Queries.Leave
{
    public class GetByIdLeaveBalanceQuery : IRequest<GetByIdLeaveBalanceDto?>
    {
        public Guid Id { get; set; }

        public GetByIdLeaveBalanceQuery(Guid id)
        {
            Id = id;
        }
    }
}
