using Em.Core.Application.CQRS.Commands.Leave;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Leave;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Commands.Leave
{
    public class CreatePublicHolidayCommandHandler : IRequestHandler<CreatePublicHolidayCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreatePublicHolidayCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreatePublicHolidayCommand request, CancellationToken cancellationToken)
        {
            var entity = request.CreatePublicHolidayDto.ToEntity();
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.PublicHolidayRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = entity.ToGetByIdDto();
            await _cache.SetAsync($"PublicHoliday:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
