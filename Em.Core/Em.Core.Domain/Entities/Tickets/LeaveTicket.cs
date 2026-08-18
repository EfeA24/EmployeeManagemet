using Em.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Tickets
{
    public class LeaveTicket : Ticket
    {
        public LeaveTicket()
        {
            Type = TicketType.Leave;
        }

        public LeaveType LeaveType { get; set; }

        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public bool IsHalfDay { get; set; }

        public decimal RequestedDayCount { get; set; }
        public bool IsBalanceDeducted { get; set; }
    }
}
