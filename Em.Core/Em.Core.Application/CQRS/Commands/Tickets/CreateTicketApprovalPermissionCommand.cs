using Em.Core.Application.DTOs.CreateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
{
    public class CreateTicketApprovalPermissionCommand : IRequest<Guid>
    {
        public CreateTicketApprovalPermissionDto CreateTicketApprovalPermissionDto { get; set; } = null!;
    }
}
