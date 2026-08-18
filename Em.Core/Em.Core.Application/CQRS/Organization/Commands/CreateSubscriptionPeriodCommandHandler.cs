using Em.Core.Application.CQRS.Organization.Commands;
using Em.Core.Application.DTOs.CreateDtos.Organization;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Commands
{
    public class CreateSubscriptionPeriodCommandHandler : IRequestHandler<CreateSubscriptionPeriodCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateSubscriptionPeriodCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateSubscriptionPeriodCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateSubscriptionPeriodDto, SubscriptionPeriod>(request.CreateSubscriptionPeriodDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.SubscriptionPeriodRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<SubscriptionPeriod, GetByIdSubscriptionPeriodDto>(entity);
            await _cache.SetAsync($"SubscriptionPeriod:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
