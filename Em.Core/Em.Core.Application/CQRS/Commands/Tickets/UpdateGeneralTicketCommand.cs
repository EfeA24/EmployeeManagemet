using Em.Core.Application.DTOs.UpdateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
{
    public class UpdateGeneralTicketCommand : IRequest
    {
        public UpdateGeneralTicketDto UpdateGeneralTicketDto { get; set; } = null!;
    }
}
