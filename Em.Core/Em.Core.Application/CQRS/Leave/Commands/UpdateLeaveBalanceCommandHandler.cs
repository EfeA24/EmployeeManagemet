using Em.Core.Application.CQRS.Leave.Commands;
using Em.Core.Application.DTOs.ReadDtos.Leave;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Leave;
using MediatR;

namespace Em.Core.Application.CQRS.Leave.Commands
{
    public class UpdateLeaveBalanceCommandHandler : IRequestHandler<UpdateLeaveBalanceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public UpdateLeaveBalanceCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task Handle(UpdateLeaveBalanceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.LeaveBalanceRepository.GetByIdAsync(request.UpdateLeaveBalanceDto.Id, cancellationToken);
            if (entity is null)
                return;

            DtoMapper.MapTo(request.UpdateLeaveBalanceDto, entity);
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.LeaveBalanceRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<LeaveBalance, GetByIdLeaveBalanceDto>(entity);
            await _cache.SetAsync($"LeaveBalance:{entity.Id}", cached, cancellationToken: cancellationToken);
        }
    }
}
