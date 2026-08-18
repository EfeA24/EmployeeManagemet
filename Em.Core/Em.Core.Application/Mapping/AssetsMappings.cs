using Em.Core.Application.DTOs.CreateDtos.Assets;
using Em.Core.Application.DTOs.ReadDtos.Assets;
using Em.Core.Application.DTOs.UpdateDtos.Assets;
using Em.Core.Domain.Entities.Assets;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.Mapping
{
    public static class AssetsMappings
    {
        public static Asset ToEntity(this CreateAssetDto dto)
        {
            return new Asset
            {
                CompanyId = dto.CompanyId,
                AssetTag = dto.AssetTag,
                Name = dto.Name,
                Category = dto.Category,
                Brand = dto.Brand,
                Model = dto.Model,
                SerialNumber = dto.SerialNumber,
                Status = dto.Status,
                PurchaseDate = dto.PurchaseDate,
                Description = dto.Description,
            };
        }

        public static void MapTo(this UpdateAssetDto dto, Asset entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.AssetTag = dto.AssetTag;
            entity.Name = dto.Name;
            entity.Category = dto.Category;
            entity.Brand = dto.Brand;
            entity.Model = dto.Model;
            entity.SerialNumber = dto.SerialNumber;
            entity.Status = dto.Status;
            entity.PurchaseDate = dto.PurchaseDate;
            entity.Description = dto.Description;
        }

        public static GetByIdAssetDto ToGetByIdDto(this Asset entity)
        {
            return new GetByIdAssetDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                AssetTag = entity.AssetTag,
                Name = entity.Name,
                Category = entity.Category,
                Brand = entity.Brand,
                Model = entity.Model,
                SerialNumber = entity.SerialNumber,
                Status = entity.Status,
                PurchaseDate = entity.PurchaseDate,
                Description = entity.Description,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllAssetDto ToGetAllDto(this Asset entity)
        {
            return new GetAllAssetDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                AssetTag = entity.AssetTag,
                Name = entity.Name,
                Category = entity.Category,
                Status = entity.Status,
            };
        }

        public static AssetAssignment ToEntity(this CreateAssetAssignmentDto dto)
        {
            return new AssetAssignment
            {
                CompanyId = dto.CompanyId,
                AssetId = dto.AssetId,
                EmployeeId = dto.EmployeeId,
                AssignedByEmployeeId = dto.AssignedByEmployeeId,
                SourceTicketId = dto.SourceTicketId,
                AssignedAt = dto.AssignedAt,
                ExpectedReturnAt = dto.ExpectedReturnAt,
                AssignmentNote = dto.AssignmentNote,
            };
        }

        public static void MapTo(this UpdateAssetAssignmentDto dto, AssetAssignment entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.AssetId = dto.AssetId;
            entity.EmployeeId = dto.EmployeeId;
            entity.AssignedByEmployeeId = dto.AssignedByEmployeeId;
            entity.SourceTicketId = dto.SourceTicketId;
            entity.AssignedAt = dto.AssignedAt;
            entity.ExpectedReturnAt = dto.ExpectedReturnAt;
            entity.ReturnedAt = dto.ReturnedAt;
            entity.AssignmentNote = dto.AssignmentNote;
            entity.ReturnNote = dto.ReturnNote;
        }

        public static GetByIdAssetAssignmentDto ToGetByIdDto(this AssetAssignment entity)
        {
            return new GetByIdAssetAssignmentDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                AssetId = entity.AssetId,
                EmployeeId = entity.EmployeeId,
                AssignedByEmployeeId = entity.AssignedByEmployeeId,
                SourceTicketId = entity.SourceTicketId,
                AssignedAt = entity.AssignedAt,
                ExpectedReturnAt = entity.ExpectedReturnAt,
                ReturnedAt = entity.ReturnedAt,
                AssignmentNote = entity.AssignmentNote,
                ReturnNote = entity.ReturnNote,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllAssetAssignmentDto ToGetAllDto(this AssetAssignment entity)
        {
            return new GetAllAssetAssignmentDto
            {
                Id = entity.Id,
                AssetId = entity.AssetId,
                EmployeeId = entity.EmployeeId,
                AssignedAt = entity.AssignedAt,
                ExpectedReturnAt = entity.ExpectedReturnAt,
                ReturnedAt = entity.ReturnedAt,
            };
        }
    }
}
