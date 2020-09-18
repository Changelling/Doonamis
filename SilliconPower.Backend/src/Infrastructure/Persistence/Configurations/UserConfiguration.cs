using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilliconPower.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Infrastructure.Persistence.Configurations
{

    public class UserConfiguration : IEntityTypeConfiguration<IUser>
    {
        public void Configure(EntityTypeBuilder<IUser> builder)
        {
            builder
                .HasMany(u => u.Bookings)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            builder
                .HasMany(u => u.Assessments)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);
        }
    }
}
