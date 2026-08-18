using Em.Core.Application.CQRS.Attendance.Commands;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Commands
{
    public class DeleteAttendanceViolationCommandHandler : IRequestHandler<DeleteAttendanceViolationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public DeleteAttendanceViolationCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(DeleteAttendanceViolationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AttendanceViolationRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.AttendanceViolationRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _cache.RemoveAsync($"AttendanceViolation:{request.Id}", cancellationToken);
        }
    }
}
