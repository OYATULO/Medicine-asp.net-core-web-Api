using Medicine.Models;
using Microsoft.EntityFrameworkCore;

namespace Medicine.API.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cabinet>().HasData(new List<Cabinet> {
                 new Cabinet { Cab_ID=1,Cab_Name ="new cabinet"  }
            });
            modelBuilder.Entity<District>().HasData(new List<District> {
                 new District { Dis_ID=1, Dis_Number ="2312"},
                 new District { Dis_ID=2, Dis_Number ="2312" }
            });
            modelBuilder.Entity<Specialization>().HasData(new List<Specialization> {
                new Specialization { Spec_ID=1, Spec_Name ="spes 1" },
                new Specialization { Spec_ID=2, Spec_Name ="spes 2" }
            });
        }
        public DbSet<Patients> Patients { get; set; } = default!;
        public DbSet<Doctors> Doctors { get; set; } = default!;
        public DbSet<District> Districts { get; set; } = default!;
        public DbSet<Cabinet> Cabinets { get; set; } = default!;
        public DbSet<Specialization> Specializations { get; set; } = default!;
    }
}
