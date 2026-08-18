using MediatR;
using Em.Core.Application.CQRS.Commands.Notes;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.CreateDtos.Notes;
using Em.Core.Domain.Entities.Notes;

namespace Em.Core.Application.CQRS.Handlers.Commands.Notes
{
    public class CreatePersonalNoteCommandHandler : IRequestHandler<CreatePersonalNoteCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonalNoteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreatePersonalNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreatePersonalNoteDto, PersonalNote>(request.CreatePersonalNoteDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.PersonalNoteRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
}
}
}
