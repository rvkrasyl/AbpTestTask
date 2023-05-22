using AbpDal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AbpDal.EntitiesTypeConfigurations
{
    public class PriceExperimentDataConfiguration : IEntityTypeConfiguration<PriceExperimentData>
    {
        public void Configure(EntityTypeBuilder<PriceExperimentData> builder)
        {
            builder.HasKey(ped => ped.Id);
        }
    }
}
