using MediatR;

namespace Em.Core.Application.CQRS.Commands.Leave
{
    public class DeletePublicHolidayCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeletePublicHolidayCommand(Guid id)
        {
            Id = id;
        }
    }
}
