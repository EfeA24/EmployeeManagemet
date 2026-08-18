using Em.Core.Application.DTOs.UpdateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
{
    public class UpdateLeaveTicketCommand : IRequest
    {
        public UpdateLeaveTicketDto UpdateLeaveTicketDto { get; set; } = null!;
    }
}
