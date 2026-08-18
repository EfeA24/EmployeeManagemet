using Em.Core.Application.Interfaces.Generic;
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
using Em.Infrastructure.Persistance.EfCore;
using Em.Infrastructure.Persistance.Implementations.Repositories.AssetsRepositories;
using Em.Infrastructure.Persistance.Implementations.Repositories.AttendanceRepositories;
using Em.Infrastructure.Persistance.Implementations.Repositories.AuditRepositories;
using Em.Infrastructure.Persistance.Implementations.Repositories.ExportRepositories;
using Em.Infrastructure.Persistance.Implementations.Repositories.IdentityRepositories;
using Em.Infrastructure.Persistance.Implementations.Repositories.LeaveRepositories;
using Em.Infrastructure.Persistance.Implementations.Repositories.NotesRepositories;
using Em.Infrastructure.Persistance.Implementations.Repositories.NotificationRepositories;
using Em.Infrastructure.Persistance.Implementations.Repositories.OrganizationRepositories;
using Em.Infrastructure.Persistance.Implementations.Repositories.TicketsRepositories;

namespace Em.Infrastructure.Persistance.Implementations.Generic
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            CompanyRepository = new CompanyRepository(context);
            CompanySettingRepository = new CompanySettingRepository(context);
            SubscriptionPeriodRepository = new SubscriptionPeriodRepository(context);
            DepartmentRepository = new DepartmentRepository(context);
            EmployeeRepository = new EmployeeRepository(context);
            EmployeeDepartmentHistoryRepository = new EmployeeDepartmentHistoryRepository(context);

            UserRepository = new UserRepository(context);
            RoleRepository = new RoleRepository(context);
            PermissionRepository = new PermissionRepository(context);
            UserRoleRepository = new UserRoleRepository(context);
            RolePermissionRepository = new RolePermissionRepository(context);
            UserPermissionRepository = new UserPermissionRepository(context);

            AssetRepository = new AssetRepository(context);
            AssetAssigmentRepository = new AssetAssigmentRepository(context);

            AttendanceRecordRepository = new AttendanceRecordRepository(context);
            AttendencePolicyRepository = new AttendencePolicyRepository(context);
            AttendanceViolationRepository = new AttendanceViolationRepository(context);
            AttendancePunchRepository = new AttendancePunchRepository(context);
            AttendanceCorrectionRepository = new AttendanceCorrectionRepository(context);

            LeaveBalanceRepository = new LeaveBalanceRepository(context);
            PublicHolidayRepository = new PublicHolidayRepository(context);

            PersonalNoteRepository = new PersonalNoteRepository(context);

            TicketRepository = new TicketRepository(context);
            LeaveTicketRepository = new LeaveTicketRepository(context);
            AssetRequestTicketRepository = new AssetRequestTicketRepository(context);
            GeneralTicketRepository = new GeneralTicketRepository(context);
            TicketDecisionRepository = new TicketDecisionRepository(context);
            TicketAttachmentRepository = new TicketAttachmentRepository(context);
            TicketApprovalPermissionRepository = new TicketApprovalPermissionRepository(context);
            TicketActionHistoryRepository = new TicketActionHistoryRepository(context);
            TicketApprovalWorkflowRepository = new TicketApprovalWorkflowRepository(context);
            TicketApprovalWorkflowStageRepository = new TicketApprovalWorkflowStageRepository(context);
            ApprovalDelegationRepository = new ApprovalDelegationRepository(context);

            NotificationRepository = new NotificationRepository(context);
            NotificationDeliveryRepository = new NotificationDeliveryRepository(context);
            NotificationPreferenceRepository = new NotificationPreferenceRepository(context);
            DeviceTokenRepository = new DeviceTokenRepository(context);

            AuditLogRepository = new AuditLogRepository(context);
            DataExportRequestRepository = new DataExportRequestRepository(context);
        }

        public ICompanyRepository CompanyRepository { get; }
        public ICompanySettingRepository CompanySettingRepository { get; }
        public ISubscriptionPeriodRepository SubscriptionPeriodRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }
        public IEmployeeRepository EmployeeRepository { get; }
        public IEmployeeDepartmentHistoryRepository EmployeeDepartmentHistoryRepository { get; }

        public IUserRepository UserRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IPermissionRepository PermissionRepository { get; }
        public IUserRoleRepository UserRoleRepository { get; }
        public IRolePermissionRepository RolePermissionRepository { get; }
        public IUserPermissionRepository UserPermissionRepository { get; }

        public IAssetRepository AssetRepository { get; }
        public IAssetAssigmentRepository AssetAssigmentRepository { get; }

        public IAttendanceRecordRepository AttendanceRecordRepository { get; }
        public IAttendencePolicyRepository AttendencePolicyRepository { get; }
        public IAttendanceViolationRepository AttendanceViolationRepository { get; }
        public IAttendancePunchRepository AttendancePunchRepository { get; }
        public IAttendanceCorrectionRepository AttendanceCorrectionRepository { get; }

        public ILeaveBalanceRepository LeaveBalanceRepository { get; }
        public IPublicHolidayRepository PublicHolidayRepository { get; }

        public IPersonalNoteRepository PersonalNoteRepository { get; }

        public ITicketRepository TicketRepository { get; }
        public ILeaveTicketRepository LeaveTicketRepository { get; }
        public IAssetRequestTicketRepository AssetRequestTicketRepository { get; }
        public IGeneralTicketRepository GeneralTicketRepository { get; }
        public ITicketDecisionRepository TicketDecisionRepository { get; }
        public ITicketAttachmentRepository TicketAttachmentRepository { get; }
        public ITicketApprovalPermissionRepository TicketApprovalPermissionRepository { get; }
        public ITicketActionHistoryRepository TicketActionHistoryRepository { get; }
        public ITicketApprovalWorkflowRepository TicketApprovalWorkflowRepository { get; }
        public ITicketApprovalWorkflowStageRepository TicketApprovalWorkflowStageRepository { get; }
        public IApprovalDelegationRepository ApprovalDelegationRepository { get; }

        public INotificationRepository NotificationRepository { get; }
        public INotificationDeliveryRepository NotificationDeliveryRepository { get; }
        public INotificationPreferenceRepository NotificationPreferenceRepository { get; }
        public IDeviceTokenRepository DeviceTokenRepository { get; }

        public IAuditLogRepository AuditLogRepository { get; }
        public IDataExportRequestRepository DataExportRequestRepository { get; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
