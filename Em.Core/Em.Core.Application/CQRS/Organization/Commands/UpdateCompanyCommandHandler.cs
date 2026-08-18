using Em.Core.Application.CQRS.Organization.Commands;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Commands
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateCompanyCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.CompanyRepository.GetByIdAsync(request.UpdateCompanyDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateCompanyDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.CompanyRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<Company, GetByIdCompanyDto>(entity);
            await _cache.SetAsync($"Company:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
