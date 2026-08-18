using Em.Core.Application.DTOs.CreateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class CreateTicketDecisionCommand : IRequest<Guid>
    {
        public CreateTicketDecisionDto CreateTicketDecisionDto { get; set; } = null!;
    }
}
