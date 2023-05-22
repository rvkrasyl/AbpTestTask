using AbpDal.Data;
using AbpDal.Entities;
using AbpDal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AbpDal.Repositories
{
    public class ButtonColorExperimentRepository : Repository<ButtonColorExperimentData>, IButtonColorExperimentRepository
    {
        public ButtonColorExperimentRepository(AbpExperimentDbContext experimentDbContext)
            : base(experimentDbContext)
        {
        }

        public override async Task AddAsync(ButtonColorExperimentData entity)
        {
            FormattableString query = $"INSERT INTO dbo.ColorExperiments (Id, ButtonColor, ExperimentDate, DeviceId) VALUES ({entity.Id}, {entity.ButtonColor}, {entity.ExperimentDate}, {entity.DeviceId});";
            await ExperimentDbContext.Database.ExecuteSqlInterpolatedAsync(query);
        }
    }
}
