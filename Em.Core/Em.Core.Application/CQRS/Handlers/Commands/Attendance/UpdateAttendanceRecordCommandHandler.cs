using Em.Core.Application.CQRS.Commands.Attendance;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Commands.Attendance
{
    public class UpdateAttendanceRecordCommandHandler : IRequestHandler<UpdateAttendanceRecordCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateAttendanceRecordCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateAttendanceRecordCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AttendanceRecordRepository.GetByIdAsync(request.UpdateAttendanceRecordDto.Id, cancellationToken);
            if (entity is null)
                return;

            request.UpdateAttendanceRecordDto.MapTo(entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AttendanceRecordRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = entity.ToGetByIdDto();
            await _cache.SetAsync($"AttendanceRecord:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
