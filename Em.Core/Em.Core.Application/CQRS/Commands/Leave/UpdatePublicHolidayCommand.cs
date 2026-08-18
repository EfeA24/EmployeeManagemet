using Em.Core.Application.DTOs.UpdateDtos.Leave;
using MediatR;

namespace Em.Core.Application.CQRS.Commands.Leave
{
    public class UpdatePublicHolidayCommand : IRequest
    {
        public UpdatePublicHolidayDto UpdatePublicHolidayDto { get; set; } = null!;
    }
}
