using Em.Core.Application.CQRS.Notes.Commands;
using Em.Core.Application.DTOs.CreateDtos.Notes;
using Em.Core.Application.DTOs.ReadDtos.Notes;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Notes;
using MediatR;

namespace Em.Core.Application.CQRS.Notes.Commands
{
    public class CreatePersonalNoteCommandHandler : IRequestHandler<CreatePersonalNoteCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreatePersonalNoteCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreatePersonalNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreatePersonalNoteDto, PersonalNote>(request.CreatePersonalNoteDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.PersonalNoteRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<PersonalNote, GetByIdPersonalNoteDto>(entity);
            await _cache.SetAsync($"PersonalNote:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
