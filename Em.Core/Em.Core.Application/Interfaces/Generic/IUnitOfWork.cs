using Em.Core.Application.Interfaces.Repositories.AssetsRepositories;
using Em.Core.Application.Interfaces.Repositories.AttendanceRepositories;
using Em.Core.Application.Interfaces.Repositories.AuditRepositories;
using Em.Core.Application.Interfaces.Repositories.ExportRepositories;
using Em.Core.Application.Interfaces.Repositories.IdentityRepositories;
using Em.Core.Application.Interfaces.Repositories.LeaveRepositories;
using Em.Core.Application.Interfaces.Repositories.NotesRepositories;
using Em.Core.Application.Interfaces.Repositories.NotificationRepositories;
using Em.Core.Application.Interfaces.Repositories.OrganizationRepositories;
using Em.Core.Application.Interfaces.Repositories.TicketsRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.Interfaces.Generic
{
    public interface IUnitOfWork
    {
        ICompanyRepository CompanyRepository { get; }
        ICompanySettingRepository CompanySettingRepository { get; }
        ISubscriptionPeriodRepository SubscriptionPeriodRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IEmployeeDepartmentHistoryRepository EmployeeDepartmentHistoryRepository { get; }

        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IPermissionRepository PermissionRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        IRolePermissionRepository RolePermissionRepository { get; }
        IUserPermissionRepository UserPermissionRepository { get; }

        IAssetRepository AssetRepository { get; }
        IAssetAssigmentRepository AssetAssigmentRepository { get; }

        IAttendanceRecordRepository AttendanceRecordRepository { get; }
        IAttendencePolicyRepository AttendencePolicyRepository { get; }
        IAttendanceViolationRepository AttendanceViolationRepository { get; }
        IAttendancePunchRepository AttendancePunchRepository { get; }
        IAttendanceCorrectionRepository AttendanceCorrectionRepository { get; }

        ILeaveBalanceRepository LeaveBalanceRepository { get; }
        IPublicHolidayRepository PublicHolidayRepository { get; }

        IPersonalNoteRepository PersonalNoteRepository { get; }

        ITicketRepository TicketRepository { get; }
        ILeaveTicketRepository LeaveTicketRepository { get; }
        IAssetRequestTicketRepository AssetRequestTicketRepository { get; }
        IGeneralTicketRepository GeneralTicketRepository { get; }
        ITicketDecisionRepository TicketDecisionRepository { get; }
        ITicketAttachmentRepository TicketAttachmentRepository { get; }
        ITicketApprovalPermissionRepository TicketApprovalPermissionRepository { get; }
        ITicketActionHistoryRepository TicketActionHistoryRepository { get; }
        ITicketApprovalWorkflowRepository TicketApprovalWorkflowRepository { get; }
        ITicketApprovalWorkflowStageRepository TicketApprovalWorkflowStageRepository { get; }
        IApprovalDelegationRepository ApprovalDelegationRepository { get; }

        INotificationRepository NotificationRepository { get; }
        INotificationDeliveryRepository NotificationDeliveryRepository { get; }
        INotificationPreferenceRepository NotificationPreferenceRepository { get; }
        IDeviceTokenRepository DeviceTokenRepository { get; }

        IAuditLogRepository AuditLogRepository { get; }
        IDataExportRequestRepository DataExportRequestRepository { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
