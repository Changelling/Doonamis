using SilliconPower.Backend.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Domain.Entities
{
    public class Activity
    {
        public Activity()
        {
            Images = new List<Image>();
            Availabilities = new List<Availability>();
            Assessments = new List<Assessment>();
            Bookings = new List<Booking>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Money Price { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public IList<Image> Images { get; set; }
        public IList<Availability> Availabilities { get; set; }
        public IList<Assessment> Assessments { get; set; }
        public IList<Booking> Bookings { get; set; }
    }
}
