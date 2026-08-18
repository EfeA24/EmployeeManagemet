using MediatR;
using Em.Core.Application.CQRS.Queries.Tickets;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Domain.Entities.Tickets;

namespace Em.Core.Application.CQRS.Handlers.Queries.Tickets
{
    public class GetAllLeaveTicketQueryHandler : IRequestHandler<GetAllLeaveTicketQuery, IReadOnlyList<GetAllLeaveTicketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllLeaveTicketQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllLeaveTicketDto>> Handle(GetAllLeaveTicketQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.LeaveTicketRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<LeaveTicket, GetAllLeaveTicketDto>)
                .ToList();
}
}
}
