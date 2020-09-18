using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Activities = new List<Activity>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Activity> Activities { get; set; }
    }
}
