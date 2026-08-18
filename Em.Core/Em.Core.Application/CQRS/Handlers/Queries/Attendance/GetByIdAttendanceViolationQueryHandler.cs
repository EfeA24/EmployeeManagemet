using MediatR;
using Em.Core.Application.CQRS.Queries.Attendance;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Domain.Entities.Attendance;

namespace Em.Core.Application.CQRS.Handlers.Queries.Attendance
{
    public class GetByIdAttendanceViolationQueryHandler : IRequestHandler<GetByIdAttendanceViolationQuery, GetByIdAttendanceViolationDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdAttendanceViolationQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByIdAttendanceViolationDto?> Handle(GetByIdAttendanceViolationQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AttendanceViolationRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return null;

            return DtoMapper.Map<AttendanceViolation, GetByIdAttendanceViolationDto>(entity);
}
}
}
