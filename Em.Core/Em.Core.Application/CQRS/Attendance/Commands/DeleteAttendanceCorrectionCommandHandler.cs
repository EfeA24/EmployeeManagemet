using Em.Core.Application.CQRS.Attendance.Commands;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using MediatR;

namespace Em.Core.Application.CQRS.Attendance.Commands
{
    public class DeleteAttendanceCorrectionCommandHandler : IRequestHandler<DeleteAttendanceCorrectionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public DeleteAttendanceCorrectionCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(DeleteAttendanceCorrectionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AttendanceCorrectionRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                return;

            await _unitOfWork.AttendanceCorrectionRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _cache.RemoveAsync($"AttendanceCorrection:{request.Id}", cancellationToken);
        }
    }
}
