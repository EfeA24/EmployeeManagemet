using Em.Core.Application.DTOs.CreateDtos.Attendance;
using Em.Core.Application.DTOs.ReadDtos.Attendance;
using Em.Core.Application.DTOs.UpdateDtos.Attendance;
using Em.Core.Domain.Entities.Attendance;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.Mapping
{
    public static class AttendanceMappings
    {
        public static AttendanceCorrection ToEntity(this CreateAttendanceCorrectionDto dto)
        {
            return new AttendanceCorrection
            {
                CompanyId = dto.CompanyId,
                AttendanceRecordId = dto.AttendanceRecordId,
                CorrectedByEmployeeId = dto.CorrectedByEmployeeId,
                FieldName = dto.FieldName,
                OldValue = dto.OldValue,
                NewValue = dto.NewValue,
                Reason = dto.Reason,
            };
        }

        public static void MapTo(this UpdateAttendanceCorrectionDto dto, AttendanceCorrection entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.AttendanceRecordId = dto.AttendanceRecordId;
            entity.CorrectedByEmployeeId = dto.CorrectedByEmployeeId;
            entity.FieldName = dto.FieldName;
            entity.OldValue = dto.OldValue;
            entity.NewValue = dto.NewValue;
            entity.Reason = dto.Reason;
            entity.CorrectedAt = dto.CorrectedAt;
        }

        public static GetByIdAttendanceCorrectionDto ToGetByIdDto(this AttendanceCorrection entity)
        {
            return new GetByIdAttendanceCorrectionDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                AttendanceRecordId = entity.AttendanceRecordId,
                CorrectedByEmployeeId = entity.CorrectedByEmployeeId,
                FieldName = entity.FieldName,
                OldValue = entity.OldValue,
                NewValue = entity.NewValue,
                Reason = entity.Reason,
                CorrectedAt = entity.CorrectedAt,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllAttendanceCorrectionDto ToGetAllDto(this AttendanceCorrection entity)
        {
            return new GetAllAttendanceCorrectionDto
            {
                Id = entity.Id,
                AttendanceRecordId = entity.AttendanceRecordId,
                FieldName = entity.FieldName,
                OldValue = entity.OldValue,
                NewValue = entity.NewValue,
                CorrectedByEmployeeId = entity.CorrectedByEmployeeId,
                CorrectedAt = entity.CorrectedAt,
            };
        }

        public static AttendancePolicy ToEntity(this CreateAttendancePolicyDto dto)
        {
            return new AttendancePolicy
            {
                CompanyId = dto.CompanyId,
                Name = dto.Name,
                ExpectedStartTime = dto.ExpectedStartTime,
                ExpectedEndTime = dto.ExpectedEndTime,
                GracePeriodMinutes = dto.GracePeriodMinutes,
                MinimumDailyWorkMinutes = dto.MinimumDailyWorkMinutes,
                IsActive = dto.IsActive,
                DepartmentId = dto.DepartmentId,
                EmployeeId = dto.EmployeeId,
            };
        }

        public static void MapTo(this UpdateAttendancePolicyDto dto, AttendancePolicy entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.Name = dto.Name;
            entity.ExpectedStartTime = dto.ExpectedStartTime;
            entity.ExpectedEndTime = dto.ExpectedEndTime;
            entity.GracePeriodMinutes = dto.GracePeriodMinutes;
            entity.MinimumDailyWorkMinutes = dto.MinimumDailyWorkMinutes;
            entity.IsActive = dto.IsActive;
            entity.DepartmentId = dto.DepartmentId;
            entity.EmployeeId = dto.EmployeeId;
        }

        public static GetByIdAttendancePolicyDto ToGetByIdDto(this AttendancePolicy entity)
        {
            return new GetByIdAttendancePolicyDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Name = entity.Name,
                ExpectedStartTime = entity.ExpectedStartTime,
                ExpectedEndTime = entity.ExpectedEndTime,
                GracePeriodMinutes = entity.GracePeriodMinutes,
                MinimumDailyWorkMinutes = entity.MinimumDailyWorkMinutes,
                IsActive = entity.IsActive,
                DepartmentId = entity.DepartmentId,
                EmployeeId = entity.EmployeeId,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllAttendancePolicyDto ToGetAllDto(this AttendancePolicy entity)
        {
            return new GetAllAttendancePolicyDto
            {
                Id = entity.Id,
                Name = entity.Name,
                ExpectedStartTime = entity.ExpectedStartTime,
                ExpectedEndTime = entity.ExpectedEndTime,
                GracePeriodMinutes = entity.GracePeriodMinutes,
                IsActive = entity.IsActive,
                DepartmentId = entity.DepartmentId,
                EmployeeId = entity.EmployeeId,
            };
        }

        public static AttendancePunch ToEntity(this CreateAttendancePunchDto dto)
        {
            return new AttendancePunch
            {
                CompanyId = dto.CompanyId,
                AttendanceRecordId = dto.AttendanceRecordId,
                Type = dto.Type,
            };
        }

        public static void MapTo(this UpdateAttendancePunchDto dto, AttendancePunch entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.AttendanceRecordId = dto.AttendanceRecordId;
            entity.Type = dto.Type;
            entity.PunchedAt = dto.PunchedAt;
        }

        public static GetByIdAttendancePunchDto ToGetByIdDto(this AttendancePunch entity)
        {
            return new GetByIdAttendancePunchDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                AttendanceRecordId = entity.AttendanceRecordId,
                Type = entity.Type,
                PunchedAt = entity.PunchedAt,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllAttendancePunchDto ToGetAllDto(this AttendancePunch entity)
        {
            return new GetAllAttendancePunchDto
            {
                Id = entity.Id,
                AttendanceRecordId = entity.AttendanceRecordId,
                Type = entity.Type,
                PunchedAt = entity.PunchedAt,
            };
        }

        public static AttendanceRecord ToEntity(this CreateAttendanceRecordDto dto)
        {
            return new AttendanceRecord
            {
                CompanyId = dto.CompanyId,
                EmployeeId = dto.EmployeeId,
                WorkDate = dto.WorkDate,
                CheckInAt = dto.CheckInAt,
                CheckOutAt = dto.CheckOutAt,
                Status = dto.Status,
                Note = dto.Note,
            };
        }

        public static void MapTo(this UpdateAttendanceRecordDto dto, AttendanceRecord entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.EmployeeId = dto.EmployeeId;
            entity.WorkDate = dto.WorkDate;
            entity.CheckInAt = dto.CheckInAt;
            entity.CheckOutAt = dto.CheckOutAt;
            entity.WorkedMinutes = dto.WorkedMinutes;
            entity.Status = dto.Status;
            entity.IsWeekend = dto.IsWeekend;
            entity.IsPublicHoliday = dto.IsPublicHoliday;
            entity.Note = dto.Note;
        }

        public static GetByIdAttendanceRecordDto ToGetByIdDto(this AttendanceRecord entity)
        {
            return new GetByIdAttendanceRecordDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                EmployeeId = entity.EmployeeId,
                WorkDate = entity.WorkDate,
                CheckInAt = entity.CheckInAt,
                CheckOutAt = entity.CheckOutAt,
                WorkedMinutes = entity.WorkedMinutes,
                Status = entity.Status,
                IsWeekend = entity.IsWeekend,
                IsPublicHoliday = entity.IsPublicHoliday,
                Note = entity.Note,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllAttendanceRecordDto ToGetAllDto(this AttendanceRecord entity)
        {
            return new GetAllAttendanceRecordDto
            {
                Id = entity.Id,
                EmployeeId = entity.EmployeeId,
                WorkDate = entity.WorkDate,
                CheckInAt = entity.CheckInAt,
                CheckOutAt = entity.CheckOutAt,
                WorkedMinutes = entity.WorkedMinutes,
                Status = entity.Status,
            };
        }

        public static AttendanceViolation ToEntity(this CreateAttendanceViolationDto dto)
        {
            return new AttendanceViolation
            {
                CompanyId = dto.CompanyId,
                AttendanceRecordId = dto.AttendanceRecordId,
                Type = dto.Type,
                DifferenceMinutes = dto.DifferenceMinutes,
                Message = dto.Message,
            };
        }

        public static void MapTo(this UpdateAttendanceViolationDto dto, AttendanceViolation entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.AttendanceRecordId = dto.AttendanceRecordId;
            entity.Type = dto.Type;
            entity.DifferenceMinutes = dto.DifferenceMinutes;
            entity.Message = dto.Message;
            entity.IsAcknowledged = dto.IsAcknowledged;
            entity.AcknowledgedAt = dto.AcknowledgedAt;
            entity.ExcuseNote = dto.ExcuseNote;
            entity.IsExcuseAccepted = dto.IsExcuseAccepted;
            entity.ReviewNote = dto.ReviewNote;
            entity.ReviewedByEmployeeId = dto.ReviewedByEmployeeId;
        }

        public static GetByIdAttendanceViolationDto ToGetByIdDto(this AttendanceViolation entity)
        {
            return new GetByIdAttendanceViolationDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                AttendanceRecordId = entity.AttendanceRecordId,
                Type = entity.Type,
                DifferenceMinutes = entity.DifferenceMinutes,
                Message = entity.Message,
                IsAcknowledged = entity.IsAcknowledged,
                AcknowledgedAt = entity.AcknowledgedAt,
                ExcuseNote = entity.ExcuseNote,
                IsExcuseAccepted = entity.IsExcuseAccepted,
                ReviewNote = entity.ReviewNote,
                ReviewedByEmployeeId = entity.ReviewedByEmployeeId,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllAttendanceViolationDto ToGetAllDto(this AttendanceViolation entity)
        {
            return new GetAllAttendanceViolationDto
            {
                Id = entity.Id,
                AttendanceRecordId = entity.AttendanceRecordId,
                Type = entity.Type,
                Message = entity.Message,
                IsAcknowledged = entity.IsAcknowledged,
                IsExcuseAccepted = entity.IsExcuseAccepted,
            };
        }
    }
}
