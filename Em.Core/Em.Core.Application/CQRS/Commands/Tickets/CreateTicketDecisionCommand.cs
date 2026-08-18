using Em.Core.Application.DTOs.CreateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
{
    public class CreateTicketDecisionCommand : IRequest<Guid>
    {
        public CreateTicketDecisionDto CreateTicketDecisionDto { get; set; } = null!;
    }
}
