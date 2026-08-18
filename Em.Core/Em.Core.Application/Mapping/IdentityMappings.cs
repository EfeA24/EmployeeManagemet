using Em.Core.Application.DTOs.CreateDtos.Identity;
using Em.Core.Application.DTOs.ReadDtos.Identity;
using Em.Core.Application.DTOs.UpdateDtos.Identity;
using Em.Core.Domain.Entities.Identity;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.Mapping
{
    public static class IdentityMappings
    {
        public static Permission ToEntity(this CreatePermissionDto dto)
        {
            return new Permission
            {
                Code = dto.Code,
                Name = dto.Name,
                Group = dto.Group,
            };
        }

        public static void MapTo(this UpdatePermissionDto dto, Permission entity)
        {
            entity.Id = dto.Id;
            entity.Code = dto.Code;
            entity.Name = dto.Name;
            entity.Group = dto.Group;
        }

        public static GetByIdPermissionDto ToGetByIdDto(this Permission entity)
        {
            return new GetByIdPermissionDto
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name,
                Group = entity.Group,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllPermissionDto ToGetAllDto(this Permission entity)
        {
            return new GetAllPermissionDto
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name,
                Group = entity.Group,
            };
        }

        public static Role ToEntity(this CreateRoleDto dto)
        {
            return new Role
            {
                CompanyId = dto.CompanyId,
                Name = dto.Name,
                SystemRoleType = dto.SystemRoleType,
                IsActive = dto.IsActive,
            };
        }

        public static void MapTo(this UpdateRoleDto dto, Role entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.Name = dto.Name;
            entity.SystemRoleType = dto.SystemRoleType;
            entity.IsActive = dto.IsActive;
        }

        public static GetByIdRoleDto ToGetByIdDto(this Role entity)
        {
            return new GetByIdRoleDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Name = entity.Name,
                SystemRoleType = entity.SystemRoleType,
                IsActive = entity.IsActive,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllRoleDto ToGetAllDto(this Role entity)
        {
            return new GetAllRoleDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Name = entity.Name,
                SystemRoleType = entity.SystemRoleType,
                IsActive = entity.IsActive,
            };
        }

        public static RolePermission ToEntity(this CreateRolePermissionDto dto)
        {
            return new RolePermission
            {
                CompanyId = dto.CompanyId,
                RoleId = dto.RoleId,
                PermissionId = dto.PermissionId,
            };
        }

        public static void MapTo(this UpdateRolePermissionDto dto, RolePermission entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.RoleId = dto.RoleId;
            entity.PermissionId = dto.PermissionId;
        }

        public static GetByIdRolePermissionDto ToGetByIdDto(this RolePermission entity)
        {
            return new GetByIdRolePermissionDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                RoleId = entity.RoleId,
                PermissionId = entity.PermissionId,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllRolePermissionDto ToGetAllDto(this RolePermission entity)
        {
            return new GetAllRolePermissionDto
            {
                Id = entity.Id,
                RoleId = entity.RoleId,
                PermissionId = entity.PermissionId,
            };
        }

        public static User ToEntity(this CreateUserDto dto)
        {
            return new User
            {
                CompanyId = dto.CompanyId,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                IsActive = dto.IsActive,
            };
        }

        public static void MapTo(this UpdateUserDto dto, User entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.Email = dto.Email;
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.PhoneNumber = dto.PhoneNumber;
            entity.IsActive = dto.IsActive;
        }

        public static GetByIdUserDto ToGetByIdDto(this User entity)
        {
            return new GetByIdUserDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PhoneNumber = entity.PhoneNumber,
                IsActive = entity.IsActive,
                LastLoginAt = entity.LastLoginAt,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllUserDto ToGetAllDto(this User entity)
        {
            return new GetAllUserDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                IsActive = entity.IsActive,
            };
        }

        public static UserPermission ToEntity(this CreateUserPermissionDto dto)
        {
            return new UserPermission
            {
                CompanyId = dto.CompanyId,
                UserId = dto.UserId,
                PermissionId = dto.PermissionId,
                IsGranted = dto.IsGranted,
            };
        }

        public static void MapTo(this UpdateUserPermissionDto dto, UserPermission entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.UserId = dto.UserId;
            entity.PermissionId = dto.PermissionId;
            entity.IsGranted = dto.IsGranted;
        }

        public static GetByIdUserPermissionDto ToGetByIdDto(this UserPermission entity)
        {
            return new GetByIdUserPermissionDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                UserId = entity.UserId,
                PermissionId = entity.PermissionId,
                IsGranted = entity.IsGranted,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllUserPermissionDto ToGetAllDto(this UserPermission entity)
        {
            return new GetAllUserPermissionDto
            {
                Id = entity.Id,
                UserId = entity.UserId,
                PermissionId = entity.PermissionId,
                IsGranted = entity.IsGranted,
            };
        }

        public static UserRole ToEntity(this CreateUserRoleDto dto)
        {
            return new UserRole
            {
                CompanyId = dto.CompanyId,
                UserId = dto.UserId,
                RoleId = dto.RoleId,
            };
        }

        public static void MapTo(this UpdateUserRoleDto dto, UserRole entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.UserId = dto.UserId;
            entity.RoleId = dto.RoleId;
        }

        public static GetByIdUserRoleDto ToGetByIdDto(this UserRole entity)
        {
            return new GetByIdUserRoleDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                UserId = entity.UserId,
                RoleId = entity.RoleId,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllUserRoleDto ToGetAllDto(this UserRole entity)
        {
            return new GetAllUserRoleDto
            {
                Id = entity.Id,
                UserId = entity.UserId,
                RoleId = entity.RoleId,
            };
        }
    }
}
