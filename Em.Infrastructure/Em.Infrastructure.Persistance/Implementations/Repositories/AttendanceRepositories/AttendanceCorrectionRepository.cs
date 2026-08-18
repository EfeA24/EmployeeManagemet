using Em.Core.Application.Interfaces.Repositories.AttendanceRepositories;
using Em.Core.Domain.Entities.Attendance;
using Em.Infrastructure.Persistance.EfCore;
using Em.Infrastructure.Persistance.Implementations.Generic;

namespace Em.Infrastructure.Persistance.Implementations.Repositories.AttendanceRepositories
{
    public class AttendanceCorrectionRepository : GenericRepository<AttendanceCorrection>, IAttendanceCorrectionRepository
    {
        public AttendanceCorrectionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
