using Em.Core.Application.DTOs.CreateDtos.Audit;
using Em.Core.Application.DTOs.ReadDtos.Audit;
using Em.Core.Application.DTOs.UpdateDtos.Audit;
using Em.Core.Domain.Entities.Audit;

namespace Em.Core.Application.Mapping
{
    public static class AuditMappings
    {
        public static AuditLog ToEntity(this CreateAuditLogDto dto)
        {
            return new AuditLog
            {
                CompanyId = dto.CompanyId,
                UserId = dto.UserId,
                Action = dto.Action,
                EntityType = dto.EntityType,
                EntityId = dto.EntityId,
                OldValues = dto.OldValues,
                NewValues = dto.NewValues,
                IpAddress = dto.IpAddress,
            };
        }

        public static void MapTo(this UpdateAuditLogDto dto, AuditLog entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.UserId = dto.UserId;
            entity.Action = dto.Action;
            entity.EntityType = dto.EntityType;
            entity.EntityId = dto.EntityId;
            entity.OldValues = dto.OldValues;
            entity.NewValues = dto.NewValues;
            entity.IpAddress = dto.IpAddress;
            entity.OccurredAt = dto.OccurredAt;
        }

        public static GetByIdAuditLogDto ToGetByIdDto(this AuditLog entity)
        {
            return new GetByIdAuditLogDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                UserId = entity.UserId,
                Action = entity.Action,
                EntityType = entity.EntityType,
                EntityId = entity.EntityId,
                OldValues = entity.OldValues,
                NewValues = entity.NewValues,
                IpAddress = entity.IpAddress,
                OccurredAt = entity.OccurredAt,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllAuditLogDto ToGetAllDto(this AuditLog entity)
        {
            return new GetAllAuditLogDto
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Action = entity.Action,
                EntityType = entity.EntityType,
                EntityId = entity.EntityId,
                OccurredAt = entity.OccurredAt,
            };
        }
    }
}
