namespace AbpBll.Entities.Models
{
    public class ExperimentDetails
    {
        public string ExperimentName { get; set; }

        public int DevicesInExperimentCount { get; set;}

        public List<ExperimentOptionDevices> ExperimentOptionDevices { get; set; }
    }
}
