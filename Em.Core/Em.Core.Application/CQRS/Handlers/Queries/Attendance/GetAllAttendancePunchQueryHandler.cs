using MediatR;
using Em.Core.Application.CQRS.Queries.Attendance;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Domain.Entities.Attendance;

namespace Em.Core.Application.CQRS.Handlers.Queries.Attendance
{
    public class GetAllAttendancePunchQueryHandler : IRequestHandler<GetAllAttendancePunchQuery, IReadOnlyList<GetAllAttendancePunchDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAttendancePunchQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllAttendancePunchDto>> Handle(GetAllAttendancePunchQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.AttendancePunchRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<AttendancePunch, GetAllAttendancePunchDto>)
                .ToList();
}
}
}
