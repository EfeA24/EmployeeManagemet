using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Enums
{
    public enum NotificationType
    {
        TicketCreated = 1,
        TicketApproved = 2,
        TicketRejected = 3,
        TicketExpired = 4,
        TicketExpiringSoon = 5,
        LeaveResult = 6,
        AssetAssigned = 7,
        AssetReturnDueSoon = 8,
        MissingAttendance = 9,
        LateArrivalWarning = 10,
        SubscriptionExpiringSoon = 11
    }
}
