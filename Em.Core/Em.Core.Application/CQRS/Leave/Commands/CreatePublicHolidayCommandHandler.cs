using Em.Core.Application.CQRS.Leave.Commands;
using Em.Core.Application.DTOs.CreateDtos.Leave;
using Em.Core.Application.DTOs.ReadDtos.Leave;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Leave;
using MediatR;

namespace Em.Core.Application.CQRS.Leave.Commands
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
            var entity = DtoMapper.Map<CreatePublicHolidayDto, PublicHoliday>(request.CreatePublicHolidayDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.PublicHolidayRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<PublicHoliday, GetByIdPublicHolidayDto>(entity);
            await _cache.SetAsync($"PublicHoliday:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
