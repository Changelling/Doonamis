using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilliconPower.Backend.Domain.Entities;
using SilliconPower.Backend.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Infrastructure.Persistence.Configurations
{

    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .HasMany(u => u.Bookings)
                .WithOne(b => (ApplicationUser)b.User)
                .HasForeignKey(b => b.UserId);

            builder
                .HasMany(u => u.Assessments)
                .WithOne(a => (ApplicationUser)a.User)
                .HasForeignKey(a => a.UserId);
        }
    }
}
