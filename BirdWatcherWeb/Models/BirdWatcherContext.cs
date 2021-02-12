using Microsoft.EntityFrameworkCore;

namespace BirdWatcherWeb.Models
{
    public class BirdWatcherContext : DbContext
    {
        public BirdWatcherContext(DbContextOptions<BirdWatcherContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BirdLogBird>()
                .HasKey(blb => new { blb.BirdID, blb.BirdLogID });

            modelBuilder.Entity<BirdLogBird>()
                .HasOne(blb => blb.Bird)
                .WithMany(b => b.BirdLogBird)
                .HasForeignKey(blb => blb.BirdID);

            modelBuilder.Entity<BirdLogBird>()
                .HasOne(blb => blb.BirdLog)
                .WithMany(bl => bl.BirdLogBird)
                .HasForeignKey(blb => blb.BirdLogID);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Bird> Birds { get; set; }
        public DbSet<BirdLog> BirdLog { get; set; }
        public DbSet<SunTrack> SunTrack { get; set; }
        public DbSet<BirdLogBird> BirdLogBird { get; set; }
        public DbSet<WatcherHealthCheck> WatcherHealthCheck { get; set; }
    }
}
