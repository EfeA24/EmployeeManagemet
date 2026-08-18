using System;
using System.Collections.Generic;
using System.Text;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.DTOs.ReadDtos.Tickets
{
    public class GetByIdLeaveTicketDto : GetByIdTicketDto
    {
        public LeaveType LeaveType { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public bool IsHalfDay { get; set; }
        public decimal RequestedDayCount { get; set; }
        public bool IsBalanceDeducted { get; set; }
    }
}