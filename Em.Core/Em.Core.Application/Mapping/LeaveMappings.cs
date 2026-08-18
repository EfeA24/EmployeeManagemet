using Em.Core.Application.DTOs.CreateDtos.Leave;
using Em.Core.Application.DTOs.ReadDtos.Leave;
using Em.Core.Application.DTOs.UpdateDtos.Leave;
using Em.Core.Domain.Entities.Leave;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.Mapping
{
    public static class LeaveMappings
    {
        public static LeaveBalance ToEntity(this CreateLeaveBalanceDto dto)
        {
            return new LeaveBalance
            {
                CompanyId = dto.CompanyId,
                EmployeeId = dto.EmployeeId,
                Year = dto.Year,
                LeaveType = dto.LeaveType,
                EntitledDays = dto.EntitledDays,
                UsedDays = dto.UsedDays,
                PendingDays = dto.PendingDays,
                RemainingDays = dto.RemainingDays,
            };
        }

        public static void MapTo(this UpdateLeaveBalanceDto dto, LeaveBalance entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.EmployeeId = dto.EmployeeId;
            entity.Year = dto.Year;
            entity.LeaveType = dto.LeaveType;
            entity.EntitledDays = dto.EntitledDays;
            entity.UsedDays = dto.UsedDays;
            entity.PendingDays = dto.PendingDays;
            entity.RemainingDays = dto.RemainingDays;
        }

        public static GetByIdLeaveBalanceDto ToGetByIdDto(this LeaveBalance entity)
        {
            return new GetByIdLeaveBalanceDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                EmployeeId = entity.EmployeeId,
                Year = entity.Year,
                LeaveType = entity.LeaveType,
                EntitledDays = entity.EntitledDays,
                UsedDays = entity.UsedDays,
                PendingDays = entity.PendingDays,
                RemainingDays = entity.RemainingDays,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllLeaveBalanceDto ToGetAllDto(this LeaveBalance entity)
        {
            return new GetAllLeaveBalanceDto
            {
                Id = entity.Id,
                EmployeeId = entity.EmployeeId,
                Year = entity.Year,
                LeaveType = entity.LeaveType,
                RemainingDays = entity.RemainingDays,
            };
        }

        public static PublicHoliday ToEntity(this CreatePublicHolidayDto dto)
        {
            return new PublicHoliday
            {
                CompanyId = dto.CompanyId,
                Name = dto.Name,
                Date = dto.Date,
                IsRecurring = dto.IsRecurring,
            };
        }

        public static void MapTo(this UpdatePublicHolidayDto dto, PublicHoliday entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.Name = dto.Name;
            entity.Date = dto.Date;
            entity.IsRecurring = dto.IsRecurring;
        }

        public static GetByIdPublicHolidayDto ToGetByIdDto(this PublicHoliday entity)
        {
            return new GetByIdPublicHolidayDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Name = entity.Name,
                Date = entity.Date,
                IsRecurring = entity.IsRecurring,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllPublicHolidayDto ToGetAllDto(this PublicHoliday entity)
        {
            return new GetAllPublicHolidayDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Name = entity.Name,
                Date = entity.Date,
                IsRecurring = entity.IsRecurring,
            };
        }
    }
}
