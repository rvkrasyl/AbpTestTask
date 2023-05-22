using AbpDal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AbpDal.EntitiesTypeConfigurations
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasIndex(d => d.DeviceToken).IsUnique();
            builder.HasOne(d => d.ButtonColorExperimentData)
                .WithOne(bced => bced.Device)
                .HasForeignKey<ButtonColorExperimentData>(bced => bced.DeviceId);
            builder.HasOne(d => d.PriceExperimentData)
                .WithOne(ped => ped.Device)
                .HasForeignKey<PriceExperimentData>(ped => ped.DeviceId);
        }
    }
}
