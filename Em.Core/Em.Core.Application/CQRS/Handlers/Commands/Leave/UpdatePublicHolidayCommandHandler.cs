using Em.Core.Application.CQRS.Commands.Leave;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Leave;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Commands.Leave
{
    public class UpdatePublicHolidayCommandHandler : IRequestHandler<UpdatePublicHolidayCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdatePublicHolidayCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdatePublicHolidayCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.PublicHolidayRepository.GetByIdAsync(request.UpdatePublicHolidayDto.Id, cancellationToken);
            if (entity is null)
                return;

            request.UpdatePublicHolidayDto.MapTo(entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.PublicHolidayRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = entity.ToGetByIdDto();
            await _cache.SetAsync($"PublicHoliday:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
