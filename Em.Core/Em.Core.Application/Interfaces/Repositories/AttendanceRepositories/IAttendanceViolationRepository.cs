using Em.Core.Application.Interfaces.Generic;
using Em.Core.Domain.Entities.Attendance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Application.Interfaces.Repositories.AttendanceRepositories
{
    public interface IAttendanceViolationRepository : IGenericRepository<AttendanceViolation>
    {
    }
}
