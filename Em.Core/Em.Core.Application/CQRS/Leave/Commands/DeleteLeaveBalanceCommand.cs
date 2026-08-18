using MediatR;

namespace Em.Core.Application.CQRS.Leave.Commands
{
    public class DeleteLeaveBalanceCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteLeaveBalanceCommand(Guid id)
        {
            Id = id;
        }
    }
}
