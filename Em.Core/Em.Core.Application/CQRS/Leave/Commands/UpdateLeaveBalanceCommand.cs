using Em.Core.Application.DTOs.UpdateDtos.Leave;
using MediatR;

namespace Em.Core.Application.CQRS.Leave.Commands
{
    public class UpdateLeaveBalanceCommand : IRequest
    {
        public UpdateLeaveBalanceDto UpdateLeaveBalanceDto { get; set; } = null!;
    }
}
