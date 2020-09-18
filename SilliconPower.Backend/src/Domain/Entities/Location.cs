using SilliconPower.Backend.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Domain.Entities
{
    public class Location
    {
        public Location()
        {
            Activities = new List<Activity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Coordinate Coordinate { get; set; }

        public IList<Activity> Activities { get; set; }
    }
}
