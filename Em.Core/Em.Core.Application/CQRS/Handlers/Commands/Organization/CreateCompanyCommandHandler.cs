using MediatR;
using Em.Core.Application.CQRS.Commands.Organization;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.CreateDtos.Organization;
using Em.Core.Domain.Entities.Organization;

namespace Em.Core.Application.CQRS.Handlers.Commands.Organization
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateCompanyDto, Company>(request.CreateCompanyDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.CompanyRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
}
}
}
