using MediatR;
using Em.Core.Application.CQRS.Commands.Organization;
using Em.Core.Application.Interfaces.Generic;

namespace Em.Core.Application.CQRS.Handlers.Commands.Organization
{
    public class DeleteCompanySettingCommandHandler : IRequestHandler<DeleteCompanySettingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCompanySettingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteCompanySettingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.CompanySettingRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.CompanySettingRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
