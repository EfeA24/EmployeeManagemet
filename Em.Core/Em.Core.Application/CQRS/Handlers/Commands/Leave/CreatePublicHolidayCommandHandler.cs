using MediatR;
using Em.Core.Application.CQRS.Commands.Leave;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.CreateDtos.Leave;
using Em.Core.Domain.Entities.Leave;

namespace Em.Core.Application.CQRS.Handlers.Commands.Leave
{
    public class CreatePublicHolidayCommandHandler : IRequestHandler<CreatePublicHolidayCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePublicHolidayCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreatePublicHolidayCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreatePublicHolidayDto, PublicHoliday>(request.CreatePublicHolidayDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.PublicHolidayRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
}
}
}
