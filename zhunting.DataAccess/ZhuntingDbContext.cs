using Microsoft.EntityFrameworkCore;
using zhunting.Data.Models;

namespace zhunting.DataAccess
{
    public class ZhuntingDbContext : DbContext
    {
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Huntable> Huntable { get; set; }
        public DbSet<Staff> Staff { get; set; }

        public ZhuntingDbContext(DbContextOptions<ZhuntingDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
