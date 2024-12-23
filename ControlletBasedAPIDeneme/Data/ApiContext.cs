using ControlletBasedAPIDeneme.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlletBasedAPIDeneme.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<HotelBooking> Bookings { get; set; } = default!;
    }
}
