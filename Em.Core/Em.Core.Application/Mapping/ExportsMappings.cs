using Em.Core.Application.DTOs.CreateDtos.Exports;
using Em.Core.Application.DTOs.ReadDtos.Exports;
using Em.Core.Application.DTOs.UpdateDtos.Exports;
using Em.Core.Domain.Entities.Exports;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.Mapping
{
    public static class ExportsMappings
    {
        public static DataExportRequest ToEntity(this CreateDataExportRequestDto dto)
        {
            return new DataExportRequest
            {
                CompanyId = dto.CompanyId,
                RequestedByUserId = dto.RequestedByUserId,
            };
        }

        public static void MapTo(this UpdateDataExportRequestDto dto, DataExportRequest entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.RequestedByUserId = dto.RequestedByUserId;
            entity.Status = dto.Status;
            entity.FilePath = dto.FilePath;
            entity.CompletedAt = dto.CompletedAt;
            entity.ExpiresAt = dto.ExpiresAt;
            entity.ErrorMessage = dto.ErrorMessage;
        }

        public static GetByIdDataExportRequestDto ToGetByIdDto(this DataExportRequest entity)
        {
            return new GetByIdDataExportRequestDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                RequestedByUserId = entity.RequestedByUserId,
                Status = entity.Status,
                FilePath = entity.FilePath,
                CompletedAt = entity.CompletedAt,
                ExpiresAt = entity.ExpiresAt,
                ErrorMessage = entity.ErrorMessage,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllDataExportRequestDto ToGetAllDto(this DataExportRequest entity)
        {
            return new GetAllDataExportRequestDto
            {
                Id = entity.Id,
                RequestedByUserId = entity.RequestedByUserId,
                Status = entity.Status,
                CompletedAt = entity.CompletedAt,
                CreateDate = entity.CreateDate,
            };
        }
    }
}
