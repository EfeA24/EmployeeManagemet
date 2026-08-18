using MediatR;
using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Domain.Entities.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetByIdLeaveTicketQueryHandler : IRequestHandler<GetByIdLeaveTicketQuery, GetByIdLeaveTicketDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdLeaveTicketQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdLeaveTicketDto?> Handle(GetByIdLeaveTicketQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.LeaveTicketRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<LeaveTicket, GetByIdLeaveTicketDto>(entity);
}
}
}
