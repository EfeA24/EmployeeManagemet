using MediatR;
using Em.Core.Application.CQRS.Commands.Organization;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Organization;

namespace Em.Core.Application.CQRS.Handlers.Commands.Organization
{
    public class UpdateCompanySettingCommandHandler : IRequestHandler<UpdateCompanySettingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCompanySettingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
}
}
}
