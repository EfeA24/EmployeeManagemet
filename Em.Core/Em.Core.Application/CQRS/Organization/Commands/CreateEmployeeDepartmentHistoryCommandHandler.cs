using Em.Core.Application.CQRS.Organization.Commands;
using Em.Core.Application.DTOs.CreateDtos.Organization;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Application.Interfaces.Cache;
using Em.Core.Application.Interfaces.Generic;
using Em.Core.Application.Mapping;
using Em.Core.Domain.Entities.Organization;
using MediatR;

namespace Em.Core.Application.CQRS.Organization.Commands
{
    public class CreateEmployeeDepartmentHistoryCommandHandler : IRequestHandler<CreateEmployeeDepartmentHistoryCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateEmployeeDepartmentHistoryCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateEmployeeDepartmentHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateEmployeeDepartmentHistoryDto, EmployeeDepartmentHistory>(request.CreateEmployeeDepartmentHistoryDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.EmployeeDepartmentHistoryRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<EmployeeDepartmentHistory, GetByIdEmployeeDepartmentHistoryDto>(entity);
            await _cache.SetAsync($"EmployeeDepartmentHistory:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
