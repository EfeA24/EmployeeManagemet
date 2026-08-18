using Em.Core.Application.DTOs.UpdateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class UpdateTicketDecisionCommand : IRequest
    {
        public UpdateTicketDecisionDto UpdateTicketDecisionDto { get; set; } = null!;
    }
}
