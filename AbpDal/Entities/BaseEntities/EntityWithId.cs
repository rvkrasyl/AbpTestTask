namespace AbpDal.Entities.BaseEntities
{
    public class EntityWithId
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
