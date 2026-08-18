using Em.Core.Application.DTOs.UpdateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class UpdateTicketApprovalPermissionCommand : IRequest
    {
        public UpdateTicketApprovalPermissionDto UpdateTicketApprovalPermissionDto { get; set; } = null!;
    }
}
