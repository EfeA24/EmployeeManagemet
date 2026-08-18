using Em.Core.Application.DTOs.ReadDtos.Leave;
using MediatR;

namespace Em.Core.Application.CQRS.Leave.Queries
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
