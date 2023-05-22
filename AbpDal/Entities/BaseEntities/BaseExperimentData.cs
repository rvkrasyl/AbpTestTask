namespace AbpDal.Entities.BaseEntities
{
    public class BaseExperimentData : EntityWithId
    {
        public DateTime ExperimentDate { get; set; } = DateTime.UtcNow;

        public Guid DeviceId { get; set; }

        public Device Device { get; set; }
    }
}
