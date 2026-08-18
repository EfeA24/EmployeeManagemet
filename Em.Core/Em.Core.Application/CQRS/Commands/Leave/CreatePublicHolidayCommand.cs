using Em.Core.Application.DTOs.CreateDtos.Leave;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Leave
{
    public class CreatePublicHolidayCommand : IRequest<Guid>
    {
        public CreatePublicHolidayDto CreatePublicHolidayDto { get; set; } = null!;
    }
}
