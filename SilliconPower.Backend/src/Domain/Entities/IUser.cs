using SilliconPower.Backend.Domain.Entities;
using SilliconPower.Backend.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Domain.Entities
{
    public interface IUser
    {
        public string Id { get; set; }
        public string Email { get; set; }

        public string Name { get; set; }
        public string Image { get; set; }

        public IList<Assessment> Assessments { get; set; }
        public IList<Booking> Bookings { get; set; }
    }
}
