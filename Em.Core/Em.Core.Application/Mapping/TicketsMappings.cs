using Em.Core.Application.DTOs.CreateDtos.Tickets;
using Em.Core.Application.DTOs.ReadDtos.Tickets;
using Em.Core.Application.DTOs.UpdateDtos.Tickets;
using Em.Core.Domain.Entities.Tickets;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.Mapping
{
    public static class TicketsMappings
    {
        public static ApprovalDelegation ToEntity(this CreateApprovalDelegationDto dto)
        {
            return new ApprovalDelegation
            {
                CompanyId = dto.CompanyId,
                FromEmployeeId = dto.FromEmployeeId,
                ToEmployeeId = dto.ToEmployeeId,
                DepartmentId = dto.DepartmentId,
                TicketType = dto.TicketType,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsActive = dto.IsActive,
            };
        }

        public static void MapTo(this UpdateApprovalDelegationDto dto, ApprovalDelegation entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.FromEmployeeId = dto.FromEmployeeId;
            entity.ToEmployeeId = dto.ToEmployeeId;
            entity.DepartmentId = dto.DepartmentId;
            entity.TicketType = dto.TicketType;
            entity.StartDate = dto.StartDate;
            entity.EndDate = dto.EndDate;
            entity.IsActive = dto.IsActive;
        }

        public static GetByIdApprovalDelegationDto ToGetByIdDto(this ApprovalDelegation entity)
        {
            return new GetByIdApprovalDelegationDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                FromEmployeeId = entity.FromEmployeeId,
                ToEmployeeId = entity.ToEmployeeId,
                DepartmentId = entity.DepartmentId,
                TicketType = entity.TicketType,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                IsActive = entity.IsActive,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllApprovalDelegationDto ToGetAllDto(this ApprovalDelegation entity)
        {
            return new GetAllApprovalDelegationDto
            {
                Id = entity.Id,
                FromEmployeeId = entity.FromEmployeeId,
                ToEmployeeId = entity.ToEmployeeId,
                TicketType = entity.TicketType,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                IsActive = entity.IsActive,
            };
        }

        public static AssetRequestTicket ToEntity(this CreateAssetRequestTicketDto dto)
        {
            return new AssetRequestTicket
            {
                CompanyId = dto.CompanyId,
                Subject = dto.Subject,
                Description = dto.Description,
                RequestedByEmployeeId = dto.RequestedByEmployeeId,
                TargetDepartmentId = dto.TargetDepartmentId,
                RequestedAssetCategory = dto.RequestedAssetCategory,
                NeededFrom = dto.NeededFrom,
                NeededUntil = dto.NeededUntil,
                PreferredAssetId = dto.PreferredAssetId,
            };
        }

        public static void MapTo(this UpdateAssetRequestTicketDto dto, AssetRequestTicket entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.Subject = dto.Subject;
            entity.Description = dto.Description;
            entity.Status = dto.Status;
            entity.RequestedByEmployeeId = dto.RequestedByEmployeeId;
            entity.TargetDepartmentId = dto.TargetDepartmentId;
            entity.RequestedAssetCategory = dto.RequestedAssetCategory;
            entity.NeededFrom = dto.NeededFrom;
            entity.NeededUntil = dto.NeededUntil;
            entity.PreferredAssetId = dto.PreferredAssetId;
            entity.AssignedAssetId = dto.AssignedAssetId;
        }

        public static GetByIdAssetRequestTicketDto ToGetByIdDto(this AssetRequestTicket entity)
        {
            return new GetByIdAssetRequestTicketDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                TicketNumber = entity.TicketNumber,
                Subject = entity.Subject,
                Description = entity.Description,
                Type = entity.Type,
                Status = entity.Status,
                ExpiresAt = entity.ExpiresAt,
                ReminderSentAt = entity.ReminderSentAt,
                ResolvedAt = entity.ResolvedAt,
                CurrentStageOrder = entity.CurrentStageOrder,
                RequestedByEmployeeId = entity.RequestedByEmployeeId,
                TargetDepartmentId = entity.TargetDepartmentId,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
                RequestedAssetCategory = entity.RequestedAssetCategory,
                NeededFrom = entity.NeededFrom,
                NeededUntil = entity.NeededUntil,
                PreferredAssetId = entity.PreferredAssetId,
                AssignedAssetId = entity.AssignedAssetId,
            };
        }

        public static GetAllAssetRequestTicketDto ToGetAllDto(this AssetRequestTicket entity)
        {
            return new GetAllAssetRequestTicketDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                TicketNumber = entity.TicketNumber,
                Subject = entity.Subject,
                Type = entity.Type,
                Status = entity.Status,
                RequestedByEmployeeId = entity.RequestedByEmployeeId,
                TargetDepartmentId = entity.TargetDepartmentId,
                ExpiresAt = entity.ExpiresAt,
                RequestedAssetCategory = entity.RequestedAssetCategory,
                NeededFrom = entity.NeededFrom,
                NeededUntil = entity.NeededUntil,
                PreferredAssetId = entity.PreferredAssetId,
                AssignedAssetId = entity.AssignedAssetId,
            };
        }

        public static GeneralTicket ToEntity(this CreateGeneralTicketDto dto)
        {
            return new GeneralTicket
            {
                CompanyId = dto.CompanyId,
                Subject = dto.Subject,
                Description = dto.Description,
                RequestedByEmployeeId = dto.RequestedByEmployeeId,
                TargetDepartmentId = dto.TargetDepartmentId,
            };
        }

        public static void MapTo(this UpdateGeneralTicketDto dto, GeneralTicket entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.Subject = dto.Subject;
            entity.Description = dto.Description;
            entity.Status = dto.Status;
            entity.RequestedByEmployeeId = dto.RequestedByEmployeeId;
            entity.TargetDepartmentId = dto.TargetDepartmentId;
        }

        public static GetByIdGeneralTicketDto ToGetByIdDto(this GeneralTicket entity)
        {
            return new GetByIdGeneralTicketDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                TicketNumber = entity.TicketNumber,
                Subject = entity.Subject,
                Description = entity.Description,
                Type = entity.Type,
                Status = entity.Status,
                ExpiresAt = entity.ExpiresAt,
                ReminderSentAt = entity.ReminderSentAt,
                ResolvedAt = entity.ResolvedAt,
                CurrentStageOrder = entity.CurrentStageOrder,
                RequestedByEmployeeId = entity.RequestedByEmployeeId,
                TargetDepartmentId = entity.TargetDepartmentId,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllGeneralTicketDto ToGetAllDto(this GeneralTicket entity)
        {
            return new GetAllGeneralTicketDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                TicketNumber = entity.TicketNumber,
                Subject = entity.Subject,
                Type = entity.Type,
                Status = entity.Status,
                RequestedByEmployeeId = entity.RequestedByEmployeeId,
                TargetDepartmentId = entity.TargetDepartmentId,
                ExpiresAt = entity.ExpiresAt,
            };
        }

        public static LeaveTicket ToEntity(this CreateLeaveTicketDto dto)
        {
            return new LeaveTicket
            {
                CompanyId = dto.CompanyId,
                Subject = dto.Subject,
                Description = dto.Description,
                RequestedByEmployeeId = dto.RequestedByEmployeeId,
                TargetDepartmentId = dto.TargetDepartmentId,
                LeaveType = dto.LeaveType,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsHalfDay = dto.IsHalfDay,
            };
        }

        public static void MapTo(this UpdateLeaveTicketDto dto, LeaveTicket entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.Subject = dto.Subject;
            entity.Description = dto.Description;
            entity.Status = dto.Status;
            entity.RequestedByEmployeeId = dto.RequestedByEmployeeId;
            entity.TargetDepartmentId = dto.TargetDepartmentId;
            entity.LeaveType = dto.LeaveType;
            entity.StartDate = dto.StartDate;
            entity.EndDate = dto.EndDate;
            entity.IsHalfDay = dto.IsHalfDay;
            entity.RequestedDayCount = dto.RequestedDayCount;
            entity.IsBalanceDeducted = dto.IsBalanceDeducted;
        }

        public static GetByIdLeaveTicketDto ToGetByIdDto(this LeaveTicket entity)
        {
            return new GetByIdLeaveTicketDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                TicketNumber = entity.TicketNumber,
                Subject = entity.Subject,
                Description = entity.Description,
                Type = entity.Type,
                Status = entity.Status,
                ExpiresAt = entity.ExpiresAt,
                ReminderSentAt = entity.ReminderSentAt,
                ResolvedAt = entity.ResolvedAt,
                CurrentStageOrder = entity.CurrentStageOrder,
                RequestedByEmployeeId = entity.RequestedByEmployeeId,
                TargetDepartmentId = entity.TargetDepartmentId,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
                LeaveType = entity.LeaveType,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                IsHalfDay = entity.IsHalfDay,
                RequestedDayCount = entity.RequestedDayCount,
                IsBalanceDeducted = entity.IsBalanceDeducted,
            };
        }

        public static GetAllLeaveTicketDto ToGetAllDto(this LeaveTicket entity)
        {
            return new GetAllLeaveTicketDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                TicketNumber = entity.TicketNumber,
                Subject = entity.Subject,
                Type = entity.Type,
                Status = entity.Status,
                RequestedByEmployeeId = entity.RequestedByEmployeeId,
                TargetDepartmentId = entity.TargetDepartmentId,
                ExpiresAt = entity.ExpiresAt,
                LeaveType = entity.LeaveType,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                IsHalfDay = entity.IsHalfDay,
                RequestedDayCount = entity.RequestedDayCount,
            };
        }

        public static void MapTo(this UpdateTicketDto dto, Ticket entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.Subject = dto.Subject;
            entity.Description = dto.Description;
            entity.Status = dto.Status;
            entity.RequestedByEmployeeId = dto.RequestedByEmployeeId;
            entity.TargetDepartmentId = dto.TargetDepartmentId;
        }

        public static GetByIdTicketDto ToGetByIdDto(this Ticket entity)
        {
            return new GetByIdTicketDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                TicketNumber = entity.TicketNumber,
                Subject = entity.Subject,
                Description = entity.Description,
                Type = entity.Type,
                Status = entity.Status,
                ExpiresAt = entity.ExpiresAt,
                ReminderSentAt = entity.ReminderSentAt,
                ResolvedAt = entity.ResolvedAt,
                CurrentStageOrder = entity.CurrentStageOrder,
                RequestedByEmployeeId = entity.RequestedByEmployeeId,
                TargetDepartmentId = entity.TargetDepartmentId,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllTicketDto ToGetAllDto(this Ticket entity)
        {
            return new GetAllTicketDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                TicketNumber = entity.TicketNumber,
                Subject = entity.Subject,
                Type = entity.Type,
                Status = entity.Status,
                RequestedByEmployeeId = entity.RequestedByEmployeeId,
                TargetDepartmentId = entity.TargetDepartmentId,
                ExpiresAt = entity.ExpiresAt,
            };
        }

        public static TicketActionHistory ToEntity(this CreateTicketActionHistoryDto dto)
        {
            return new TicketActionHistory
            {
                CompanyId = dto.CompanyId,
                TicketId = dto.TicketId,
                ActionType = dto.ActionType,
                PerformedByEmployeeId = dto.PerformedByEmployeeId,
                Note = dto.Note,
            };
        }

        public static void MapTo(this UpdateTicketActionHistoryDto dto, TicketActionHistory entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.TicketId = dto.TicketId;
            entity.ActionType = dto.ActionType;
            entity.PerformedByEmployeeId = dto.PerformedByEmployeeId;
            entity.Note = dto.Note;
            entity.PerformedAt = dto.PerformedAt;
        }

        public static GetByIdTicketActionHistoryDto ToGetByIdDto(this TicketActionHistory entity)
        {
            return new GetByIdTicketActionHistoryDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                TicketId = entity.TicketId,
                ActionType = entity.ActionType,
                PerformedByEmployeeId = entity.PerformedByEmployeeId,
                Note = entity.Note,
                PerformedAt = entity.PerformedAt,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllTicketActionHistoryDto ToGetAllDto(this TicketActionHistory entity)
        {
            return new GetAllTicketActionHistoryDto
            {
                Id = entity.Id,
                TicketId = entity.TicketId,
                ActionType = entity.ActionType,
                PerformedByEmployeeId = entity.PerformedByEmployeeId,
                PerformedAt = entity.PerformedAt,
            };
        }

        public static TicketApprovalPermission ToEntity(this CreateTicketApprovalPermissionDto dto)
        {
            return new TicketApprovalPermission
            {
                CompanyId = dto.CompanyId,
                EmployeeId = dto.EmployeeId,
                DepartmentId = dto.DepartmentId,
                TicketType = dto.TicketType,
                CanApprove = dto.CanApprove,
                CanReject = dto.CanReject,
                IsActive = dto.IsActive,
            };
        }

        public static void MapTo(this UpdateTicketApprovalPermissionDto dto, TicketApprovalPermission entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.EmployeeId = dto.EmployeeId;
            entity.DepartmentId = dto.DepartmentId;
            entity.TicketType = dto.TicketType;
            entity.CanApprove = dto.CanApprove;
            entity.CanReject = dto.CanReject;
            entity.IsActive = dto.IsActive;
        }

        public static GetByIdTicketApprovalPermissionDto ToGetByIdDto(this TicketApprovalPermission entity)
        {
            return new GetByIdTicketApprovalPermissionDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                EmployeeId = entity.EmployeeId,
                DepartmentId = entity.DepartmentId,
                TicketType = entity.TicketType,
                CanApprove = entity.CanApprove,
                CanReject = entity.CanReject,
                IsActive = entity.IsActive,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllTicketApprovalPermissionDto ToGetAllDto(this TicketApprovalPermission entity)
        {
            return new GetAllTicketApprovalPermissionDto
            {
                Id = entity.Id,
                EmployeeId = entity.EmployeeId,
                DepartmentId = entity.DepartmentId,
                TicketType = entity.TicketType,
                CanApprove = entity.CanApprove,
                CanReject = entity.CanReject,
                IsActive = entity.IsActive,
            };
        }

        public static TicketApprovalWorkflow ToEntity(this CreateTicketApprovalWorkflowDto dto)
        {
            return new TicketApprovalWorkflow
            {
                CompanyId = dto.CompanyId,
                Name = dto.Name,
                TicketType = dto.TicketType,
                IsActive = dto.IsActive,
            };
        }

        public static void MapTo(this UpdateTicketApprovalWorkflowDto dto, TicketApprovalWorkflow entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.Name = dto.Name;
            entity.TicketType = dto.TicketType;
            entity.IsActive = dto.IsActive;
        }

        public static GetByIdTicketApprovalWorkflowDto ToGetByIdDto(this TicketApprovalWorkflow entity)
        {
            return new GetByIdTicketApprovalWorkflowDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Name = entity.Name,
                TicketType = entity.TicketType,
                IsActive = entity.IsActive,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllTicketApprovalWorkflowDto ToGetAllDto(this TicketApprovalWorkflow entity)
        {
            return new GetAllTicketApprovalWorkflowDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Name = entity.Name,
                TicketType = entity.TicketType,
                IsActive = entity.IsActive,
            };
        }

        public static TicketApprovalWorkflowStage ToEntity(this CreateTicketApprovalWorkflowStageDto dto)
        {
            return new TicketApprovalWorkflowStage
            {
                CompanyId = dto.CompanyId,
                WorkflowId = dto.WorkflowId,
                Order = dto.Order,
                Name = dto.Name,
                TargetDepartmentId = dto.TargetDepartmentId,
                RequiredRoleId = dto.RequiredRoleId,
            };
        }

        public static void MapTo(this UpdateTicketApprovalWorkflowStageDto dto, TicketApprovalWorkflowStage entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.WorkflowId = dto.WorkflowId;
            entity.Order = dto.Order;
            entity.Name = dto.Name;
            entity.TargetDepartmentId = dto.TargetDepartmentId;
            entity.RequiredRoleId = dto.RequiredRoleId;
        }

        public static GetByIdTicketApprovalWorkflowStageDto ToGetByIdDto(this TicketApprovalWorkflowStage entity)
        {
            return new GetByIdTicketApprovalWorkflowStageDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                WorkflowId = entity.WorkflowId,
                Order = entity.Order,
                Name = entity.Name,
                TargetDepartmentId = entity.TargetDepartmentId,
                RequiredRoleId = entity.RequiredRoleId,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllTicketApprovalWorkflowStageDto ToGetAllDto(this TicketApprovalWorkflowStage entity)
        {
            return new GetAllTicketApprovalWorkflowStageDto
            {
                Id = entity.Id,
                WorkflowId = entity.WorkflowId,
                Order = entity.Order,
                Name = entity.Name,
                TargetDepartmentId = entity.TargetDepartmentId,
                RequiredRoleId = entity.RequiredRoleId,
            };
        }

        public static TicketAttachment ToEntity(this CreateTicketAttachmentDto dto)
        {
            return new TicketAttachment
            {
                CompanyId = dto.CompanyId,
                TicketId = dto.TicketId,
                FileName = dto.FileName,
                StoragePath = dto.StoragePath,
                ContentType = dto.ContentType,
                FileSize = dto.FileSize,
            };
        }

        public static void MapTo(this UpdateTicketAttachmentDto dto, TicketAttachment entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.TicketId = dto.TicketId;
            entity.FileName = dto.FileName;
            entity.StoragePath = dto.StoragePath;
            entity.ContentType = dto.ContentType;
            entity.FileSize = dto.FileSize;
        }

        public static GetByIdTicketAttachmentDto ToGetByIdDto(this TicketAttachment entity)
        {
            return new GetByIdTicketAttachmentDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                TicketId = entity.TicketId,
                FileName = entity.FileName,
                StoragePath = entity.StoragePath,
                ContentType = entity.ContentType,
                FileSize = entity.FileSize,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllTicketAttachmentDto ToGetAllDto(this TicketAttachment entity)
        {
            return new GetAllTicketAttachmentDto
            {
                Id = entity.Id,
                TicketId = entity.TicketId,
                FileName = entity.FileName,
                ContentType = entity.ContentType,
                FileSize = entity.FileSize,
            };
        }

        public static TicketDecision ToEntity(this CreateTicketDecisionDto dto)
        {
            return new TicketDecision
            {
                CompanyId = dto.CompanyId,
                TicketId = dto.TicketId,
                WorkflowStageId = dto.WorkflowStageId,
                StageOrder = dto.StageOrder,
                DecidedByEmployeeId = dto.DecidedByEmployeeId,
                Decision = dto.Decision,
                Note = dto.Note,
            };
        }

        public static void MapTo(this UpdateTicketDecisionDto dto, TicketDecision entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.TicketId = dto.TicketId;
            entity.WorkflowStageId = dto.WorkflowStageId;
            entity.StageOrder = dto.StageOrder;
            entity.DecidedByEmployeeId = dto.DecidedByEmployeeId;
            entity.Decision = dto.Decision;
            entity.Note = dto.Note;
            entity.DecidedAt = dto.DecidedAt;
        }

        public static GetByIdTicketDecisionDto ToGetByIdDto(this TicketDecision entity)
        {
            return new GetByIdTicketDecisionDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                TicketId = entity.TicketId,
                WorkflowStageId = entity.WorkflowStageId,
                StageOrder = entity.StageOrder,
                DecidedByEmployeeId = entity.DecidedByEmployeeId,
                Decision = entity.Decision,
                Note = entity.Note,
                DecidedAt = entity.DecidedAt,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllTicketDecisionDto ToGetAllDto(this TicketDecision entity)
        {
            return new GetAllTicketDecisionDto
            {
                Id = entity.Id,
                TicketId = entity.TicketId,
                StageOrder = entity.StageOrder,
                DecidedByEmployeeId = entity.DecidedByEmployeeId,
                Decision = entity.Decision,
                DecidedAt = entity.DecidedAt,
            };
        }
    }
}
