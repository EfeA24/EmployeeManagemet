using Em.Core.Application.CQRS.Commands.Attendance;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Attendance;
using MediatR;

namespace Em.Core.Application.CQRS.Handlers.Commands.Attendance
{
    public class UpdateAttendancePolicyCommandHandler : IRequestHandler<UpdateAttendancePolicyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateAttendancePolicyCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateAttendancePolicyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AttendencePolicyRepository.GetByIdAsync(request.UpdateAttendancePolicyDto.Id, cancellationToken);
            if (entity is null)
                return;

            request.UpdateAttendancePolicyDto.MapTo(entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AttendencePolicyRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = entity.ToGetByIdDto();
            await _cache.SetAsync($"AttendancePolicy:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
