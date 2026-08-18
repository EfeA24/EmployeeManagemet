using Em.Core.Application.DTOs.UpdateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class UpdateTicketActionHistoryCommand : IRequest
    {
        public UpdateTicketActionHistoryDto UpdateTicketActionHistoryDto { get; set; } = null!;
    }
}
