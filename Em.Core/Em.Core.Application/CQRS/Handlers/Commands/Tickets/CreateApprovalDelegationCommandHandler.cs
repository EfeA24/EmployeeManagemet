using MediatR;
using Em.Core.Application.CQRS.Commands.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.CreateDtos.Tickets;
using Em.Core.Domain.Entities.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Commands.Tickets
{
    public class CreateApprovalDelegationCommandHandler : IRequestHandler<CreateApprovalDelegationCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateApprovalDelegationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateApprovalDelegationCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateApprovalDelegationDto, ApprovalDelegation>(request.CreateApprovalDelegationDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.ApprovalDelegationRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
}
}
}
