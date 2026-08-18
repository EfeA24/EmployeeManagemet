using MediatR;
using Em.Core.Application.CQRS.Commands.Leave;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Leave
{
    public class DeletePublicHolidayCommandHandler : IRequestHandler<DeletePublicHolidayCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePublicHolidayCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeletePublicHolidayCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.PublicHolidayRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.PublicHolidayRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
