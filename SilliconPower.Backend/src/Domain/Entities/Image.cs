using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Domain.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
