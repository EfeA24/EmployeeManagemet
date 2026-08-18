using Em.Core.Application.DTOs.UpdateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class UpdateGeneralTicketCommand : IRequest
    {
        public UpdateGeneralTicketDto UpdateGeneralTicketDto { get; set; } = null!;
    }
}
