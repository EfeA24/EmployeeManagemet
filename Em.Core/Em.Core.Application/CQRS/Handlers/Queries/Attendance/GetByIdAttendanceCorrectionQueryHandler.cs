using MediatR;
using Em.Core.Application.CQRS.Queries.Attendance;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Domain.Entities.Attendance;

namespace Em.Core.Application.CQRS.Handlers.Queries.Attendance
{
    public class GetByIdAttendanceCorrectionQueryHandler : IRequestHandler<GetByIdAttendanceCorrectionQuery, GetByIdAttendanceCorrectionDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdAttendanceCorrectionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdAttendanceCorrectionDto?> Handle(GetByIdAttendanceCorrectionQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AttendanceCorrectionRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<AttendanceCorrection, GetByIdAttendanceCorrectionDto>(entity);
}
}
}
