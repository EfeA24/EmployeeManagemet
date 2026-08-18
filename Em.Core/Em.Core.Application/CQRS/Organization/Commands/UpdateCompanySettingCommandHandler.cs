using Em.Core.Application.CQRS.Organization.Commands;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Commands
{
    public class UpdateCompanySettingCommandHandler : IRequestHandler<UpdateCompanySettingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateCompanySettingCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateCompanySettingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.CompanySettingRepository.GetByIdAsync(request.UpdateCompanySettingDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateCompanySettingDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.CompanySettingRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<CompanySetting, GetByIdCompanySettingDto>(entity);
            await _cache.SetAsync($"CompanySetting:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
