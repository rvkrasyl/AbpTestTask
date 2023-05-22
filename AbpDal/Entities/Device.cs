using AbpDal.Entities.BaseEntities;

namespace AbpDal.Entities
{
    public class Device : EntityWithId
    {
        public string DeviceToken { get; set; }

        public ButtonColorExperimentData ButtonColorExperimentData { get; set; }

        public PriceExperimentData PriceExperimentData { get; set; }
    }
}
