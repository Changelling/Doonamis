using SilliconPower.Backend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Domain.Entities
{
    public class Booking: AuditableEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public string UserId { get; set; }
        public IUser User { get; set; }        
    }
}
