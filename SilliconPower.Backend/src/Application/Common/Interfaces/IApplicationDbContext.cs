using SilliconPower.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace SilliconPower.Backend.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Activity> Activities { get; set; }
        DbSet<Assessment> Assessments { get; set; }
        DbSet<Booking> Bookings { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<Image> Images { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
