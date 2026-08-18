using Em.Core.Application.DTOs.CreateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Tickets.Commands
{
    public class CreateGeneralTicketCommand : IRequest<Guid>
    {
        public CreateGeneralTicketDto CreateGeneralTicketDto { get; set; } = null!;
    }
}
