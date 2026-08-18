using MediatR;
using Em.Core.Application.CQRS.Commands.Notes;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.UpdateDtos.Notes;

namespace Em.Core.Application.CQRS.Handlers.Commands.Notes
{
    public class UpdatePersonalNoteCommandHandler : IRequestHandler<UpdatePersonalNoteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePersonalNoteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdatePersonalNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.PersonalNoteRepository.GetByIdAsync(request.UpdatePersonalNoteDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdatePersonalNoteDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.PersonalNoteRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
}
}
}
