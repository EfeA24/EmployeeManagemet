using Em.Core.Application.DTOs.CreateDtos.Tickets;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Tickets
{
    public class CreateTicketActionHistoryCommand : IRequest<Guid>
    {
        public CreateTicketActionHistoryDto CreateTicketActionHistoryDto { get; set; } = null!;
    }
}
