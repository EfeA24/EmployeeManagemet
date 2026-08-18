using Em.Core.Application.CQRS.Organization.Commands;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Commands
{
    public class DeleteCompanySettingCommandHandler : IRequestHandler<DeleteCompanySettingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public DeleteCompanySettingCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(DeleteCompanySettingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.CompanySettingRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.CompanySettingRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _cache.RemoveAsync($"CompanySetting:{request.Id}", cancellationToken);
        }
    }
}
