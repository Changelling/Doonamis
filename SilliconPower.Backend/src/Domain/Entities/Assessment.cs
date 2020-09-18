using SilliconPower.Backend.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Domain.Entities
{
    public class Assessment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public Rating Rating { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public string UserId { get; set; }
        public IUser User { get; set; }
    }
}
