using Em.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Entities.Tickets
{
    public class GeneralTicket : Ticket
    {
        public GeneralTicket()
        {
            Type = TicketType.General;
        }
    }
}
