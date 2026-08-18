using MediatR;
using Em.Core.Application.CQRS.Queries.Attendance;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Domain.Entities.Attendance;

namespace Em.Core.Application.CQRS.Handlers.Queries.Attendance
{
    public class GetAllAttendanceCorrectionQueryHandler : IRequestHandler<GetAllAttendanceCorrectionQuery, IReadOnlyList<GetAllAttendanceCorrectionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAttendanceCorrectionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<GetAllAttendanceCorrectionDto>> Handle(GetAllAttendanceCorrectionQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.AttendanceCorrectionRepository.GetAllAsync(cancellationToken);

            return entities
                .Select(DtoMapper.Map<AttendanceCorrection, GetAllAttendanceCorrectionDto>)
                .ToList();
}
}
}
