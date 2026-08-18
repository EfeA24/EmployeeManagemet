using Em.Core.Application.CQRS.Commands.Notes;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Notes;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Commands.Notes
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

            request.UpdatePersonalNoteDto.MapTo(entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.PersonalNoteRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = entity.ToGetByIdDto();
            await _cache.SetAsync($"PersonalNote:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
