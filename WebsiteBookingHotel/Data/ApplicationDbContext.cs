using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebsiteBookingHotel.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BLog> Blog { get; set; }

        public DbSet<Booking> Booking { get; set; }

        public DbSet<ImageCollection> ImageCollection { get; set; }

        public DbSet<Room> Room { get; set; }

        public DbSet<TypeRoom> TypeRoom { get; set; }

        public DbSet<WebsiteInfo> WebsiteInfo { get; set; }
    }
}
