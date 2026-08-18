using MediatR;
using Em.Core.Application.CQRS.Commands.Leave;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Leave;

namespace Em.Core.Application.CQRS.Handlers.Commands.Leave
{
    public class UpdatePublicHolidayCommandHandler : IRequestHandler<UpdatePublicHolidayCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePublicHolidayCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdatePublicHolidayCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.PublicHolidayRepository.GetByIdAsync(request.UpdatePublicHolidayDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdatePublicHolidayDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.PublicHolidayRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
