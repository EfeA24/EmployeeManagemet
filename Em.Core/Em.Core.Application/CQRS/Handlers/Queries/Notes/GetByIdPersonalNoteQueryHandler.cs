using MediatR;
using Em.Core.Application.CQRS.Queries.Notes;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Notes;
using Em.Core.Domain.Entities.Notes;

namespace Em.Core.Application.CQRS.Handlers.Queries.Notes
{
    public class GetByIdPersonalNoteQueryHandler : IRequestHandler<GetByIdPersonalNoteQuery, GetByIdPersonalNoteDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdPersonalNoteQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdPersonalNoteDto?> Handle(GetByIdPersonalNoteQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.PersonalNoteRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<PersonalNote, GetByIdPersonalNoteDto>(entity);
}
}
}
