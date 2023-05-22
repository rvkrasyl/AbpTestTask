using AbpDal.Entities;
using AbpDal.EntitiesTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AbpDal.Data
{
    public class AbpExperimentDbContext : DbContext
    {
        public AbpExperimentDbContext(DbContextOptions<AbpExperimentDbContext> options)
            : base(options)
        {
        }

        public DbSet<ButtonColorExperimentData> ColorExperiments { get; set; }

        public DbSet<PriceExperimentData> PriceExperiments { get; set; }

        public DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ButtonColorExperimentDataConfiguration());
            modelBuilder.ApplyConfiguration(new PriceExperimentDataConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceConfiguration());
        }
    }
}
