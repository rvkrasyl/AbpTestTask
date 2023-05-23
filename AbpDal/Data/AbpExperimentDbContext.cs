using AbpDal.Entities;
using AbpDal.EntitiesTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AbpDal.Data
{
    /// <inheritdoc/>
    public class AbpExperimentDbContext : DbContext
    {
        /// <summary>
        /// Initialize DbContext based on inputted options.
        /// </summary>
        /// <param name="options">Options needed to establish connection to actual AbpExperiment DB</param>
        public AbpExperimentDbContext(DbContextOptions<AbpExperimentDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Db set which contains all the data about conducted experiments with button color.
        /// </summary>
        public DbSet<ButtonColorExperimentData> ColorExperiments { get; set; }

        /// <summary>
        /// Db set which contains all the data about conducted experiments with price options.
        /// </summary>
        public DbSet<PriceExperimentData> PriceExperiments { get; set; }

        /// <summary>
        /// Db set that contains all the data about devices which took part in experiments.
        /// </summary>
        public DbSet<Device> Devices { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ButtonColorExperimentDataConfiguration());
            modelBuilder.ApplyConfiguration(new PriceExperimentDataConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceConfiguration());
        }
    }
}
