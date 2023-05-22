using AbpDal.Data;
using AbpDal.Entities;
using AbpDal.Repositories.Interfaces;

namespace AbpDal.Repositories
{
    public class ButtonColorExperimentRepository : Repository<ButtonColorExperimentData>, IButtonColorExperimentRepository
    {
        public ButtonColorExperimentRepository(AbpExperimentDbContext experimentDbContext)
            : base(experimentDbContext)
        {
        }
    }
}
