using Em.Core.Application.DTOs.CreateDtos.Leave;
using MediatR;

namespace Em.Core.Application.CQRS.Leave.Commands
{
    public class CreateLeaveBalanceCommand : IRequest<Guid>
    {
        public CreateLeaveBalanceDto CreateLeaveBalanceDto { get; set; } = null!;
    }
}
