using Em.Core.Application.Interfaces.Repositories.AttendanceRepositories;
using Em.Core.Domain.Entities.Attendance;
using Em.Infrastructure.Persistance.EfCore;
using Em.Infrastructure.Persistance.Implementations.Generic;

namespace Em.Infrastructure.Persistance.Implementations.Repositories.AttendanceRepositories
{
    public class AttendancePunchRepository : GenericRepository<AttendancePunch>, IAttendancePunchRepository
    {
        public AttendancePunchRepository(AppDbContext context) : base(context)
        {
        }
    }
}
