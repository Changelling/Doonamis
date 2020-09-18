using Microsoft.AspNetCore.Identity;
using SilliconPower.Backend.Domain.Entities;
using SilliconPower.Backend.Domain.ValueObjects;
using System.Collections.Generic;

namespace SilliconPower.Backend.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser, IUser
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public ApplicationUser()
        {
            Assessments = new List<Assessment>();
            Bookings = new List<Booking>();
        }
        
        public IList<Assessment> Assessments { get; set; }
        public IList<Booking> Bookings { get; set; }
    }
}
