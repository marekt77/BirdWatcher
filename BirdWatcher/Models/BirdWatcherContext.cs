using Microsoft.EntityFrameworkCore;

namespace BirdWatcherBackend.Models
{
    public class BirdWatcherContext : DbContext
    {
        public BirdWatcherContext(DbContextOptions<BirdWatcherContext> options) : base(options) { }

        public DbSet<Bird> Birds { get; set; }
        public DbSet<BirdLog> BirdLog { get; set; }
    }
}
