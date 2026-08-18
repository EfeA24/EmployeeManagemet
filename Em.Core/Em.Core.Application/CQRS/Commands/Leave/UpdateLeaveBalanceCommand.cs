using Em.Core.Application.DTOs.UpdateDtos.Leave;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Leave
{
    public class UpdateLeaveBalanceCommand : IRequest
    {
        public UpdateLeaveBalanceDto UpdateLeaveBalanceDto { get; set; } = null!;
    }
}
