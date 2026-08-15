using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Enums
{
    public enum AttendanceViolationType
    {
        Absence = 1,
        EarlyDeparture = 2,
        LateArrival = 3,
        MissingCheckIn = 4,
        MissingCheckOut = 5
    }
}
