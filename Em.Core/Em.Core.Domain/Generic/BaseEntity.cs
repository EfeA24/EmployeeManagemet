using System;
using System.Collections.Generic;
using System.Text;

namespace Em.Core.Domain.Generic
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
