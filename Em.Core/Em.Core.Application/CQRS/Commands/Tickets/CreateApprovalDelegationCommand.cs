using Em.Core.Application.DTOs.CreateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
{
    public class CreateApprovalDelegationCommand : IRequest<Guid>
    {
        public CreateApprovalDelegationDto CreateApprovalDelegationDto { get; set; } = null!;
    }
}
