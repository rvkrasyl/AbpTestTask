namespace AbpDal.Entities.EnumClasses
{
    public class AvailableExperiments : Enumeration
    {
        public AvailableExperiments(int id, string name)
            : base(id, name)
        {
        }

        public static AvailableExperiments ButtonColor => new(1, "button_color");

        public static AvailableExperiments PriceOption => new(1, "price_option");
    }
}
