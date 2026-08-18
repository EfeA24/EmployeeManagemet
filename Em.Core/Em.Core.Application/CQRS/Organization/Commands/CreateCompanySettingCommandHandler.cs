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
    public class CreateCompanySettingCommandHandler : IRequestHandler<CreateCompanySettingCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateCompanySettingCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateCompanySettingCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateCompanySettingDto, CompanySetting>(request.CreateCompanySettingDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.CompanySettingRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<CompanySetting, GetByIdCompanySettingDto>(entity);
            await _cache.SetAsync($"CompanySetting:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
