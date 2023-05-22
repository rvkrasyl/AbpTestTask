using AbpDal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AbpDal.EntitiesTypeConfigurations
{
    public class ButtonColorExperimentDataConfiguration : IEntityTypeConfiguration<ButtonColorExperimentData>
    {
        public void Configure(EntityTypeBuilder<ButtonColorExperimentData> builder)
        {
            builder.HasKey(bced => bced.Id);
        }
    }
}
