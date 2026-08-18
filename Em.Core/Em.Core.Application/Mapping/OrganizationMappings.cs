using Em.Core.Application.DTOs.CreateDtos.Organization;
using Em.Core.Application.DTOs.ReadDtos.Organization;
using Em.Core.Application.DTOs.UpdateDtos.Organization;
using Em.Core.Domain.Entities.Organization;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.Mapping
{
    public static class OrganizationMappings
    {
        public static Company ToEntity(this CreateCompanyDto dto)
        {
            return new Company
            {
                Name = dto.Name,
                LegalName = dto.LegalName,
                TaxNumber = dto.TaxNumber,
                Email = dto.Email,
                IsActive = dto.IsActive,
                Status = dto.Status,
                PersonnelLimit = dto.PersonnelLimit,
                SubscriptionStartDate = dto.SubscriptionStartDate,
                SubscriptionEndDate = dto.SubscriptionEndDate,
                GracePeriodEndDate = dto.GracePeriodEndDate,
            };
        }

        public static void MapTo(this UpdateCompanyDto dto, Company entity)
        {
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            entity.LegalName = dto.LegalName;
            entity.TaxNumber = dto.TaxNumber;
            entity.Email = dto.Email;
            entity.IsActive = dto.IsActive;
            entity.Status = dto.Status;
            entity.PersonnelLimit = dto.PersonnelLimit;
            entity.SubscriptionStartDate = dto.SubscriptionStartDate;
            entity.SubscriptionEndDate = dto.SubscriptionEndDate;
            entity.GracePeriodEndDate = dto.GracePeriodEndDate;
            entity.WarnedAt = dto.WarnedAt;
        }

        public static GetByIdCompanyDto ToGetByIdDto(this Company entity)
        {
            return new GetByIdCompanyDto
            {
                Id = entity.Id,
                Name = entity.Name,
                LegalName = entity.LegalName,
                TaxNumber = entity.TaxNumber,
                Email = entity.Email,
                IsActive = entity.IsActive,
                Status = entity.Status,
                PersonnelLimit = entity.PersonnelLimit,
                SubscriptionStartDate = entity.SubscriptionStartDate,
                SubscriptionEndDate = entity.SubscriptionEndDate,
                GracePeriodEndDate = entity.GracePeriodEndDate,
                WarnedAt = entity.WarnedAt,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllCompanyDto ToGetAllDto(this Company entity)
        {
            return new GetAllCompanyDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                IsActive = entity.IsActive,
                Status = entity.Status,
                SubscriptionEndDate = entity.SubscriptionEndDate,
            };
        }

        public static CompanySetting ToEntity(this CreateCompanySettingDto dto)
        {
            return new CompanySetting
            {
                CompanyId = dto.CompanyId,
                TicketExpirationDays = dto.TicketExpirationDays,
                TicketExpiryReminderDays = dto.TicketExpiryReminderDays,
                AllowPastDateLeaveRequests = dto.AllowPastDateLeaveRequests,
                CountWeekendsAsLeaveDays = dto.CountWeekendsAsLeaveDays,
                CountPublicHolidaysAsLeaveDays = dto.CountPublicHolidaysAsLeaveDays,
                DefaultAnnualLeaveDays = dto.DefaultAnnualLeaveDays,
                SaturdayIsWeekend = dto.SaturdayIsWeekend,
                SundayIsWeekend = dto.SundayIsWeekend,
                AllowMultipleAttendancePunchesPerDay = dto.AllowMultipleAttendancePunchesPerDay,
                AssetReturnReminderDays = dto.AssetReturnReminderDays,
            };
        }

        public static void MapTo(this UpdateCompanySettingDto dto, CompanySetting entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.TicketExpirationDays = dto.TicketExpirationDays;
            entity.TicketExpiryReminderDays = dto.TicketExpiryReminderDays;
            entity.AllowPastDateLeaveRequests = dto.AllowPastDateLeaveRequests;
            entity.CountWeekendsAsLeaveDays = dto.CountWeekendsAsLeaveDays;
            entity.CountPublicHolidaysAsLeaveDays = dto.CountPublicHolidaysAsLeaveDays;
            entity.DefaultAnnualLeaveDays = dto.DefaultAnnualLeaveDays;
            entity.SaturdayIsWeekend = dto.SaturdayIsWeekend;
            entity.SundayIsWeekend = dto.SundayIsWeekend;
            entity.AllowMultipleAttendancePunchesPerDay = dto.AllowMultipleAttendancePunchesPerDay;
            entity.AssetReturnReminderDays = dto.AssetReturnReminderDays;
        }

        public static GetByIdCompanySettingDto ToGetByIdDto(this CompanySetting entity)
        {
            return new GetByIdCompanySettingDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                TicketExpirationDays = entity.TicketExpirationDays,
                TicketExpiryReminderDays = entity.TicketExpiryReminderDays,
                AllowPastDateLeaveRequests = entity.AllowPastDateLeaveRequests,
                CountWeekendsAsLeaveDays = entity.CountWeekendsAsLeaveDays,
                CountPublicHolidaysAsLeaveDays = entity.CountPublicHolidaysAsLeaveDays,
                DefaultAnnualLeaveDays = entity.DefaultAnnualLeaveDays,
                SaturdayIsWeekend = entity.SaturdayIsWeekend,
                SundayIsWeekend = entity.SundayIsWeekend,
                AllowMultipleAttendancePunchesPerDay = entity.AllowMultipleAttendancePunchesPerDay,
                AssetReturnReminderDays = entity.AssetReturnReminderDays,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllCompanySettingDto ToGetAllDto(this CompanySetting entity)
        {
            return new GetAllCompanySettingDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                TicketExpirationDays = entity.TicketExpirationDays,
                DefaultAnnualLeaveDays = entity.DefaultAnnualLeaveDays,
            };
        }

        public static Department ToEntity(this CreateDepartmentDto dto)
        {
            return new Department
            {
                CompanyId = dto.CompanyId,
                Name = dto.Name,
                Email = dto.Email,
                Description = dto.Description,
                IsActive = dto.IsActive,
            };
        }

        public static void MapTo(this UpdateDepartmentDto dto, Department entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.Name = dto.Name;
            entity.Email = dto.Email;
            entity.Description = dto.Description;
            entity.IsActive = dto.IsActive;
        }

        public static GetByIdDepartmentDto ToGetByIdDto(this Department entity)
        {
            return new GetByIdDepartmentDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Name = entity.Name,
                Email = entity.Email,
                Description = entity.Description,
                IsActive = entity.IsActive,
                IsDeleted = entity.IsDeleted,
                DeletedAt = entity.DeletedAt,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllDepartmentDto ToGetAllDto(this Department entity)
        {
            return new GetAllDepartmentDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Name = entity.Name,
                Email = entity.Email,
                IsActive = entity.IsActive,
            };
        }

        public static Employee ToEntity(this CreateEmployeeDto dto)
        {
            return new Employee
            {
                CompanyId = dto.CompanyId,
                UserId = dto.UserId,
                EmployeeNumber = dto.EmployeeNumber,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                JobTitle = dto.JobTitle,
                HireDate = dto.HireDate,
                TerminationDate = dto.TerminationDate,
                IsActive = dto.IsActive,
                DepartmentId = dto.DepartmentId,
            };
        }

        public static void MapTo(this UpdateEmployeeDto dto, Employee entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.UserId = dto.UserId;
            entity.EmployeeNumber = dto.EmployeeNumber;
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.Email = dto.Email;
            entity.PhoneNumber = dto.PhoneNumber;
            entity.JobTitle = dto.JobTitle;
            entity.HireDate = dto.HireDate;
            entity.TerminationDate = dto.TerminationDate;
            entity.IsActive = dto.IsActive;
            entity.DepartmentId = dto.DepartmentId;
        }

        public static GetByIdEmployeeDto ToGetByIdDto(this Employee entity)
        {
            return new GetByIdEmployeeDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                UserId = entity.UserId,
                EmployeeNumber = entity.EmployeeNumber,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                JobTitle = entity.JobTitle,
                HireDate = entity.HireDate,
                TerminationDate = entity.TerminationDate,
                IsActive = entity.IsActive,
                DepartmentId = entity.DepartmentId,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllEmployeeDto ToGetAllDto(this Employee entity)
        {
            return new GetAllEmployeeDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                EmployeeNumber = entity.EmployeeNumber,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                JobTitle = entity.JobTitle,
                DepartmentId = entity.DepartmentId,
                IsActive = entity.IsActive,
            };
        }

        public static EmployeeDepartmentHistory ToEntity(this CreateEmployeeDepartmentHistoryDto dto)
        {
            return new EmployeeDepartmentHistory
            {
                CompanyId = dto.CompanyId,
                EmployeeId = dto.EmployeeId,
                DepartmentId = dto.DepartmentId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                ChangeNote = dto.ChangeNote,
            };
        }

        public static void MapTo(this UpdateEmployeeDepartmentHistoryDto dto, EmployeeDepartmentHistory entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.EmployeeId = dto.EmployeeId;
            entity.DepartmentId = dto.DepartmentId;
            entity.StartDate = dto.StartDate;
            entity.EndDate = dto.EndDate;
            entity.ChangeNote = dto.ChangeNote;
        }

        public static GetByIdEmployeeDepartmentHistoryDto ToGetByIdDto(this EmployeeDepartmentHistory entity)
        {
            return new GetByIdEmployeeDepartmentHistoryDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                EmployeeId = entity.EmployeeId,
                DepartmentId = entity.DepartmentId,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                ChangeNote = entity.ChangeNote,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllEmployeeDepartmentHistoryDto ToGetAllDto(this EmployeeDepartmentHistory entity)
        {
            return new GetAllEmployeeDepartmentHistoryDto
            {
                Id = entity.Id,
                EmployeeId = entity.EmployeeId,
                DepartmentId = entity.DepartmentId,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
            };
        }

        public static SubscriptionPeriod ToEntity(this CreateSubscriptionPeriodDto dto)
        {
            return new SubscriptionPeriod
            {
                CompanyId = dto.CompanyId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                GracePeriodEndDate = dto.GracePeriodEndDate,
                IsPaid = dto.IsPaid,
                Amount = dto.Amount,
                Note = dto.Note,
            };
        }

        public static void MapTo(this UpdateSubscriptionPeriodDto dto, SubscriptionPeriod entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.StartDate = dto.StartDate;
            entity.EndDate = dto.EndDate;
            entity.GracePeriodEndDate = dto.GracePeriodEndDate;
            entity.IsPaid = dto.IsPaid;
            entity.Amount = dto.Amount;
            entity.Note = dto.Note;
        }

        public static GetByIdSubscriptionPeriodDto ToGetByIdDto(this SubscriptionPeriod entity)
        {
            return new GetByIdSubscriptionPeriodDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                GracePeriodEndDate = entity.GracePeriodEndDate,
                IsPaid = entity.IsPaid,
                Amount = entity.Amount,
                Note = entity.Note,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllSubscriptionPeriodDto ToGetAllDto(this SubscriptionPeriod entity)
        {
            return new GetAllSubscriptionPeriodDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                IsPaid = entity.IsPaid,
                Amount = entity.Amount,
            };
        }
    }
}
