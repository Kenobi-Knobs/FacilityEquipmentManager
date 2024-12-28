using FacilityEquipmentManager.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FacilityEquipmentManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Facility> Facilities { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>().HasIndex(c => c.FacilityCode);
        }
    }
}
