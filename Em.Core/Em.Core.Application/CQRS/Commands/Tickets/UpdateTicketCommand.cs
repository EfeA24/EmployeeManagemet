using Em.Core.Application.DTOs.UpdateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
{
    public class UpdateTicketCommand : IRequest
    {
        public UpdateTicketDto UpdateTicketDto { get; set; } = null!;
    }
}
