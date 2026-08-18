using Em.Core.Domain.Entities.Assets;
using Em.Core.Domain.Entities.Attendance;
using Em.Core.Domain.Entities.Audit;
using Em.Core.Domain.Entities.Exports;
using Em.Core.Domain.Entities.Identity;
using Em.Core.Domain.Entities.Leave;
using Em.Core.Domain.Entities.Notes;
using Em.Core.Domain.Entities.Notifications;
using Em.Core.Domain.Entities.Organization;
using Em.Core.Domain.Entities.Tickets;
using Em.Core.Domain.Enums;
using Em.Core.Domain.Generic;
using Microsoft.EntityFrameworkCore;

namespace Em.Infrastructure.Persistance.EfCore
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanySetting> CompanySettings { get; set; }
        public DbSet<SubscriptionPeriod> SubscriptionPeriods { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetAssignment> AssetAssignments { get; set; }

        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }
        public DbSet<AttendancePolicy> AttendancePolicies { get; set; }
        public DbSet<AttendanceViolation> AttendanceViolations { get; set; }
        public DbSet<AttendancePunch> AttendancePunches { get; set; }
        public DbSet<AttendanceCorrection> AttendanceCorrections { get; set; }

        public DbSet<LeaveBalance> LeaveBalances { get; set; }
        public DbSet<PublicHoliday> PublicHolidays { get; set; }

        public DbSet<PersonalNote> PersonalNotes { get; set; }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<GeneralTicket> GeneralTickets { get; set; }
        public DbSet<LeaveTicket> LeaveTickets { get; set; }
        public DbSet<AssetRequestTicket> AssetRequestTickets { get; set; }
        public DbSet<TicketDecision> TicketDecisions { get; set; }
        public DbSet<TicketAttachment> TicketAttachments { get; set; }
        public DbSet<TicketApprovalPermission> TicketApprovalPermissions { get; set; }
        public DbSet<TicketActionHistory> TicketActionHistories { get; set; }
        public DbSet<TicketApprovalWorkflow> TicketApprovalWorkflows { get; set; }
        public DbSet<TicketApprovalWorkflowStage> TicketApprovalWorkflowStages { get; set; }
        public DbSet<ApprovalDelegation> ApprovalDelegations { get; set; }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationDelivery> NotificationDeliveries { get; set; }
        public DbSet<NotificationPreference> NotificationPreferences { get; set; }
        public DbSet<DeviceToken> DeviceTokens { get; set; }

        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<DataExportRequest> DataExportRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureTenantEntities(modelBuilder);
            ConfigureOrganization(modelBuilder);
            ConfigureIdentity(modelBuilder);
            ConfigureAssets(modelBuilder);
            ConfigureAttendance(modelBuilder);
            ConfigureLeave(modelBuilder);
            ConfigureNotes(modelBuilder);
            ConfigureTickets(modelBuilder);
            ConfigureNotifications(modelBuilder);
            ConfigureAuditAndExports(modelBuilder);
        }

        private static void ConfigureTenantEntities(ModelBuilder modelBuilder)
        {
            var tenantTypes = modelBuilder.Model.GetEntityTypes()
                .Where(entityType =>
                    typeof(TenantEntity).IsAssignableFrom(entityType.ClrType)
                    && (entityType.BaseType == null || !typeof(TenantEntity).IsAssignableFrom(entityType.BaseType.ClrType)))
                .Select(entityType => entityType.ClrType)
                .ToList();

            foreach (var clrType in tenantTypes)
            {
                modelBuilder.Entity(clrType)
                    .HasOne(typeof(Company), nameof(TenantEntity.Company))
                    .WithMany()
                    .HasForeignKey(nameof(TenantEntity.CompanyId))
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }

        private static void ConfigureOrganization(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(x => x.Name).HasMaxLength(200).IsRequired();
                entity.Property(x => x.Email).HasMaxLength(256).IsRequired();
            });

            modelBuilder.Entity<CompanySetting>()
                .HasOne(x => x.Company)
                .WithOne(x => x.Setting)
                .HasForeignKey<CompanySetting>(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SubscriptionPeriod>()
                .HasOne(x => x.Company)
                .WithMany(x => x.SubscriptionPeriods)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SubscriptionPeriod>()
                .Property(x => x.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasOne(x => x.Company)
                    .WithMany(x => x.Departments)
                    .HasForeignKey(x => x.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(x => x.Name).HasMaxLength(200).IsRequired();
                entity.Property(x => x.Email).HasMaxLength(256).IsRequired();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(x => x.Company)
                    .WithMany(x => x.Employees)
                    .HasForeignKey(x => x.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.User)
                    .WithOne(x => x.Employee)
                    .HasForeignKey<Employee>(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Department)
                    .WithMany(x => x.Employees)
                    .HasForeignKey(x => x.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(x => x.EmployeeNumber).HasMaxLength(50).IsRequired();
                entity.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(x => x.LastName).HasMaxLength(100).IsRequired();
                entity.Property(x => x.Email).HasMaxLength(256).IsRequired();

                entity.HasIndex(x => new { x.CompanyId, x.EmployeeNumber }).IsUnique();
            });

            modelBuilder.Entity<EmployeeDepartmentHistory>(entity =>
            {
                entity.HasOne(x => x.Employee)
                    .WithMany(x => x.DepartmentHistory)
                    .HasForeignKey(x => x.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Department)
                    .WithMany()
                    .HasForeignKey(x => x.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureIdentity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(x => x.Company)
                    .WithMany(x => x.Users)
                    .HasForeignKey(x => x.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(x => x.Email).HasMaxLength(256).IsRequired();
                entity.HasIndex(x => new { x.CompanyId, x.Email }).IsUnique();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(x => x.Name).HasMaxLength(100).IsRequired();
                entity.HasIndex(x => new { x.CompanyId, x.Name }).IsUnique();
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(x => x.Code).HasMaxLength(100).IsRequired();
                entity.Property(x => x.Name).HasMaxLength(200).IsRequired();
                entity.HasIndex(x => x.Code).IsUnique();
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasOne(x => x.User)
                    .WithMany(x => x.UserRoles)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Role)
                    .WithMany(x => x.UserRoles)
                    .HasForeignKey(x => x.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(x => new { x.UserId, x.RoleId }).IsUnique();
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasOne(x => x.Role)
                    .WithMany(x => x.RolePermissions)
                    .HasForeignKey(x => x.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Permission)
                    .WithMany(x => x.RolePermissions)
                    .HasForeignKey(x => x.PermissionId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(x => new { x.RoleId, x.PermissionId }).IsUnique();
            });

            modelBuilder.Entity<UserPermission>(entity =>
            {
                entity.HasOne(x => x.User)
                    .WithMany(x => x.UserPermissions)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Permission)
                    .WithMany(x => x.UserPermissions)
                    .HasForeignKey(x => x.PermissionId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(x => new { x.UserId, x.PermissionId }).IsUnique();
            });
        }

        private static void ConfigureAssets(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>(entity =>
            {
                entity.Property(x => x.AssetTag).HasMaxLength(100).IsRequired();
                entity.Property(x => x.Name).HasMaxLength(200).IsRequired();
                entity.Property(x => x.Category).HasMaxLength(100).IsRequired();
                entity.HasIndex(x => new { x.CompanyId, x.AssetTag }).IsUnique();
            });

            modelBuilder.Entity<AssetAssignment>(entity =>
            {
                entity.HasOne(x => x.Asset)
                    .WithMany(x => x.Assignments)
                    .HasForeignKey(x => x.AssetId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Employee)
                    .WithMany(x => x.AssetAssignments)
                    .HasForeignKey(x => x.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.AssignedByEmployee)
                    .WithMany()
                    .HasForeignKey(x => x.AssignedByEmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.SourceTicket)
                    .WithMany()
                    .HasForeignKey(x => x.SourceTicketId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureAttendance(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendanceRecord>(entity =>
            {
                entity.HasOne(x => x.Employee)
                    .WithMany(x => x.AttendanceRecords)
                    .HasForeignKey(x => x.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(x => new { x.EmployeeId, x.WorkDate }).IsUnique();
            });

            modelBuilder.Entity<AttendancePolicy>(entity =>
            {
                entity.HasOne(x => x.Department)
                    .WithMany()
                    .HasForeignKey(x => x.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Employee)
                    .WithMany()
                    .HasForeignKey(x => x.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AttendanceViolation>(entity =>
            {
                entity.HasOne(x => x.AttendanceRecord)
                    .WithMany(x => x.Violations)
                    .HasForeignKey(x => x.AttendanceRecordId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.ReviewedByEmployee)
                    .WithMany()
                    .HasForeignKey(x => x.ReviewedByEmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AttendancePunch>()
                .HasOne(x => x.AttendanceRecord)
                .WithMany(x => x.Punches)
                .HasForeignKey(x => x.AttendanceRecordId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AttendanceCorrection>(entity =>
            {
                entity.HasOne(x => x.AttendanceRecord)
                    .WithMany(x => x.Corrections)
                    .HasForeignKey(x => x.AttendanceRecordId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.CorrectedByEmployee)
                    .WithMany()
                    .HasForeignKey(x => x.CorrectedByEmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureLeave(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeaveBalance>(entity =>
            {
                entity.HasOne(x => x.Employee)
                    .WithMany(x => x.LeaveBalances)
                    .HasForeignKey(x => x.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(x => x.EntitledDays).HasPrecision(8, 2);
                entity.Property(x => x.UsedDays).HasPrecision(8, 2);
                entity.Property(x => x.PendingDays).HasPrecision(8, 2);
                entity.Property(x => x.RemainingDays).HasPrecision(8, 2);

                entity.HasIndex(x => new { x.EmployeeId, x.Year, x.LeaveType }).IsUnique();
            });

            modelBuilder.Entity<PublicHoliday>(entity =>
            {
                entity.Property(x => x.Name).HasMaxLength(200).IsRequired();
                entity.HasIndex(x => new { x.CompanyId, x.Date }).IsUnique();
            });
        }

        private static void ConfigureNotes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonalNote>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.PersonalNotes)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void ConfigureTickets(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasDiscriminator(x => x.Type)
                    .HasValue<GeneralTicket>(TicketType.General)
                    .HasValue<LeaveTicket>(TicketType.Leave)
                    .HasValue<AssetRequestTicket>(TicketType.AssetRequest);

                entity.HasOne(x => x.RequestedByEmployee)
                    .WithMany(x => x.Tickets)
                    .HasForeignKey(x => x.RequestedByEmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.TargetDepartment)
                    .WithMany()
                    .HasForeignKey(x => x.TargetDepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(x => x.TicketNumber).HasMaxLength(50).IsRequired();
                entity.Property(x => x.Subject).HasMaxLength(300).IsRequired();
                entity.HasIndex(x => new { x.CompanyId, x.TicketNumber }).IsUnique();
            });

            modelBuilder.Entity<LeaveTicket>()
                .Property(x => x.RequestedDayCount)
                .HasPrecision(8, 2);

            modelBuilder.Entity<AssetRequestTicket>(entity =>
            {
                entity.HasOne(x => x.PreferredAsset)
                    .WithMany()
                    .HasForeignKey(x => x.PreferredAssetId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.AssignedAsset)
                    .WithMany()
                    .HasForeignKey(x => x.AssignedAssetId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TicketDecision>(entity =>
            {
                entity.HasOne(x => x.Ticket)
                    .WithMany(x => x.Decisions)
                    .HasForeignKey(x => x.TicketId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.WorkflowStage)
                    .WithMany()
                    .HasForeignKey(x => x.WorkflowStageId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.DecidedByEmployee)
                    .WithMany()
                    .HasForeignKey(x => x.DecidedByEmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TicketAttachment>()
                .HasOne(x => x.Ticket)
                .WithMany(x => x.Attachments)
                .HasForeignKey(x => x.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TicketActionHistory>(entity =>
            {
                entity.HasOne(x => x.Ticket)
                    .WithMany(x => x.ActionHistory)
                    .HasForeignKey(x => x.TicketId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.PerformedByEmployee)
                    .WithMany()
                    .HasForeignKey(x => x.PerformedByEmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TicketApprovalPermission>(entity =>
            {
                entity.HasOne(x => x.Employee)
                    .WithMany()
                    .HasForeignKey(x => x.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Department)
                    .WithMany(x => x.ApprovalPermissions)
                    .HasForeignKey(x => x.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TicketApprovalWorkflowStage>(entity =>
            {
                entity.HasOne(x => x.Workflow)
                    .WithMany(x => x.Stages)
                    .HasForeignKey(x => x.WorkflowId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.TargetDepartment)
                    .WithMany()
                    .HasForeignKey(x => x.TargetDepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.RequiredRole)
                    .WithMany()
                    .HasForeignKey(x => x.RequiredRoleId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ApprovalDelegation>(entity =>
            {
                entity.HasOne(x => x.FromEmployee)
                    .WithMany()
                    .HasForeignKey(x => x.FromEmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.ToEmployee)
                    .WithMany()
                    .HasForeignKey(x => x.ToEmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Department)
                    .WithMany()
                    .HasForeignKey(x => x.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureNotifications(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasOne(x => x.User)
                    .WithMany()
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(x => x.Title).HasMaxLength(300).IsRequired();
            });

            modelBuilder.Entity<NotificationDelivery>()
                .HasOne(x => x.Notification)
                .WithMany(x => x.Deliveries)
                .HasForeignKey(x => x.NotificationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<NotificationPreference>(entity =>
            {
                entity.HasOne(x => x.User)
                    .WithMany()
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(x => new { x.UserId, x.NotificationType }).IsUnique();
            });

            modelBuilder.Entity<DeviceToken>(entity =>
            {
                entity.HasOne(x => x.User)
                    .WithMany()
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(x => x.Token).HasMaxLength(500).IsRequired();
                entity.HasIndex(x => x.Token).IsUnique();
            });
        }

        private static void ConfigureAuditAndExports(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.HasOne(x => x.User)
                    .WithMany()
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(x => x.Action).HasMaxLength(200).IsRequired();
                entity.Property(x => x.EntityType).HasMaxLength(200).IsRequired();
            });

            modelBuilder.Entity<DataExportRequest>()
                .HasOne(x => x.RequestedByUser)
                .WithMany()
                .HasForeignKey(x => x.RequestedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
