namespace AbpDal.Entities.ExperimentOptions
{
    public static class PriceExperimentOptions
    {
        private static List<byte> PriceOptions =>
            new()
            {
                10,
                20,
                50,
                5,
            };

        public static byte GetExperimentalPrice()
        {
            var randomValue = new Random().Next(1, 101);
            byte priceOption = randomValue switch
            {
                <= 75 => PriceOptions[0],
                <= 85 => PriceOptions[1],
                <= 90 => PriceOptions[2],
                _ => PriceOptions[3],
            };

            return priceOption;
        }
    }
}