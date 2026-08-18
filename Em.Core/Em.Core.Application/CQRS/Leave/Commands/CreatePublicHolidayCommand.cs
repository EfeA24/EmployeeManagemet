using Em.Core.Application.DTOs.CreateDtos.Leave;
using MediatR;

namespace Em.Core.Application.CQRS.Leave.Commands
{
    public class CreatePublicHolidayCommand : IRequest<Guid>
    {
        public CreatePublicHolidayDto CreatePublicHolidayDto { get; set; } = null!;
    }
}
