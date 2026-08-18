using Em.Core.Application.CQRS.Notes.Commands;
using Em.Core.Application.DTOs.ReadDtos.Notes;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Notes;
using MediatR;

namespace Em.Core.Application.CQRS.Notes.Commands
{
    public class UpdatePersonalNoteCommandHandler : IRequestHandler<UpdatePersonalNoteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdatePersonalNoteCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
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

            var cached = DtoMapper.Map<PersonalNote, GetByIdPersonalNoteDto>(entity);
            await _cache.SetAsync($"PersonalNote:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
