using Microsoft.EntityFrameworkCore;
using Modmon.Modules.Speakers.Core.Entities;

namespace Modmon.Modules.Speakers.Core.DAL
{
    public class SpeakersDbContext : DbContext
    {
        public DbSet<Speaker> Speakers { get; set; }

        public SpeakersDbContext(DbContextOptions<SpeakersDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("speakers");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
