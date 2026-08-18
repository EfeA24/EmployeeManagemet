using Em.Core.Application.DTOs.UpdateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
{
    public class UpdateTicketActionHistoryCommand : IRequest
    {
        public UpdateTicketActionHistoryDto UpdateTicketActionHistoryDto { get; set; } = null!;
    }
}
