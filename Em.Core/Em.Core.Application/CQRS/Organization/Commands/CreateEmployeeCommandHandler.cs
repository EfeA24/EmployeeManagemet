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
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;

        public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, ICacheService cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = DtoMapper.Map<CreateEmployeeDto, Employee>(request.CreateEmployeeDto);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;

            await _unitOfWork.EmployeeRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cached = DtoMapper.Map<Employee, GetByIdEmployeeDto>(entity);
            await _cache.SetAsync($"Employee:{entity.Id}", cached, cancellationToken: cancellationToken);

            return entity.Id;
        }
    }
}
