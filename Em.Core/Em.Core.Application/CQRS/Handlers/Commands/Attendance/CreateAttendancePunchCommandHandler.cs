using MediatR;
using Em.Core.Application.CQRS.Commands.Attendance;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Application.DTOs.CreateDtos.Attendance;
using Em.Core.Domain.Entities.Attendance;

namespace Em.Core.Application.CQRS.Handlers.Commands.Attendance
{
    public class CreateAttendancePunchCommandHandler : IRequestHandler<CreateAttendancePunchCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAttendancePunchCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateAttendancePunchCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateAttendancePunchDto, AttendancePunch>(request.CreateAttendancePunchDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.AttendancePunchRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
}
}
}
