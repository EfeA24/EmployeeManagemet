using Em.Core.Application.DTOs.CreateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
{
    public class CreateLeaveTicketCommand : IRequest<Guid>
    {
        public CreateLeaveTicketDto CreateLeaveTicketDto { get; set; } = null!;
    }
}
