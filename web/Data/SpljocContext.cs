using web.Models;
using Microsoft.EntityFrameworkCore;

namespace web.Data
{
    public class SpljocContext : DbContext
    {
        public SpljocContext(DbContextOptions<SpljocContext> options) : base(options)
        {
        }

        public DbSet<Bazen> Bazeni { get; set; }
        public DbSet<Plavalec> Plavalci { get; set; }
        public DbSet<Ucitelj> Ucitelji { get; set; }
        public DbSet<Skupina> Skupine { get; set; }
        public DbSet<Izvedba> Izvedbe { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bazen>().ToTable("Bazen");
            modelBuilder.Entity<Plavalec>().ToTable("Plavalec");
            modelBuilder.Entity<Ucitelj>().ToTable("Ucitelj");
            modelBuilder.Entity<Skupina>().ToTable("Skupine");
            modelBuilder.Entity<Izvedba>().ToTable("Izvedba");
        }
    }
}