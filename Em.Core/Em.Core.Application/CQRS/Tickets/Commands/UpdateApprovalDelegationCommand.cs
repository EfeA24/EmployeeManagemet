using Em.Core.Application.DTOs.UpdateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class UpdateApprovalDelegationCommand : IRequest
    {
        public UpdateApprovalDelegationDto UpdateApprovalDelegationDto { get; set; } = null!;
    }
}
