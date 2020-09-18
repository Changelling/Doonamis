using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Domain.Entities
{
    public class Availability
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
