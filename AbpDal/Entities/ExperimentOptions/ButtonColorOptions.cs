namespace AbpDal.Entities.ExperimentOptions
{
    public static class ButtonColorOptions
    {
        private static List<string> ColorOptions =>
            new()
            {
                "#FF0000",
                "#00FF00",
                "#0000FF",
            };

        public static string GetExperimentalColor()
            => ColorOptions[new Random().Next(0, 2)];
    }
}
