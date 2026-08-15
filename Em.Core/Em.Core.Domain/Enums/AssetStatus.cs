using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Enums
{
    public enum AssetStatus
    {
        Available = 1,
        Assigned = 2,
        InMaintenance = 3,
        Lost = 4,
        Reserved = 5,
        Retired = 6
    }
}
