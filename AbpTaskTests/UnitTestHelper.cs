using AbpBll.Entities.Models;
using AbpDal.Entities;
using AbpDal.Entities.EnumClasses;

namespace AbpTaskTests
{
    public static class UnitTestHelper
    {
        public static List<Device> GetDevicesWithAllData()
        {
            return new()
            {
                new()
                {
                    Id = Guid.Parse("00c3aef1-c14b-49d9-8656-ed7cb8219912"),
                    DeviceToken = "awesomeToken",
                    PriceExperimentData = new()
                    {
                        DeviceId = Guid.Parse("00c3aef1-c14b-49d9-8656-ed7cb8219912"),
                        Price = 10
                    },
                    ButtonColorExperimentData = new()
                    {
                        DeviceId = Guid.Parse("00c3aef1-c14b-49d9-8656-ed7cb8219912"),
                        ButtonColor = "#FF0000",
                    }
                },
                new()
                {
                    Id = Guid.Parse("ddcc2246-7a00-4f48-9fda-793776fcf360"),
                    DeviceToken = "vibrantToken",
                    PriceExperimentData = new()
                    {
                        DeviceId = Guid.Parse("ddcc2246-7a00-4f48-9fda-793776fcf360"),
                        Price = 20
                    },
                    ButtonColorExperimentData = new()
                    {
                        DeviceId = Guid.Parse("ddcc2246-7a00-4f48-9fda-793776fcf360"),
                        ButtonColor = "#00FF00",
                    }
                },
                new()
                {
                    Id = Guid.Parse("1f57e730-8e61-40bf-a790-806528f5b3c5"),
                    DeviceToken = "amazingToken",
                    PriceExperimentData = new()
                    {
                        DeviceId = Guid.Parse("1f57e730-8e61-40bf-a790-806528f5b3c5"),
                        Price = 10
                    },
                    ButtonColorExperimentData = new()
                    {
                        DeviceId = Guid.Parse("1f57e730-8e61-40bf-a790-806528f5b3c5"),
                        ButtonColor = "#00FF00",
                    }
                },
                new()
                {
                    Id = Guid.Parse("c1cebda5-0d0d-4b5d-8543-68f6db204781"),
                    DeviceToken = "strikingToken",
                    PriceExperimentData = new()
                    {
                        DeviceId = Guid.Parse("c1cebda5-0d0d-4b5d-8543-68f6db204781"),
                        Price = 10
                    },
                    ButtonColorExperimentData = new()
                    {
                        DeviceId = Guid.Parse("c1cebda5-0d0d-4b5d-8543-68f6db204781"),
                        ButtonColor = "#FF0000",
                    }
                },
                new()
                {
                    Id = Guid.Parse("112a2f51-a152-43f0-ab2f-4cc777bcd652"),
                    DeviceToken = "radiantToken",
                    PriceExperimentData = new()
                    {
                        DeviceId = Guid.Parse("112a2f51-a152-43f0-ab2f-4cc777bcd652"),
                        Price = 5
                    },
                    ButtonColorExperimentData = new()
                    {
                        DeviceId = Guid.Parse("112a2f51-a152-43f0-ab2f-4cc777bcd652"),
                        ButtonColor = "#00FF00",
                    }
                },
                new()
                {
                    Id = Guid.Parse("74f77ca4-ef46-4e8d-ac21-fe20a1d762de"),
                    DeviceToken = "additionalToken",
                    PriceExperimentData = new()
                    {
                        DeviceId = Guid.Parse("74f77ca4-ef46-4e8d-ac21-fe20a1d762de"),
                        Price = 50
                    },
                }
            };
        }

        public static List<Device> GetDevicesWithColorExperimentData()
        {
            return new()
            {
                new()
                {
                    Id = Guid.Parse("00c3aef1-c14b-49d9-8656-ed7cb8219912"),
                    DeviceToken = "awesomeToken",
                    ButtonColorExperimentData = new()
                    {
                        DeviceId = Guid.Parse("00c3aef1-c14b-49d9-8656-ed7cb8219912"),
                        ButtonColor = "#FF0000",
                    }
                },
                new()
                {
                    Id = Guid.Parse("ddcc2246-7a00-4f48-9fda-793776fcf360"),
                    DeviceToken = "vibrantToken",
                    ButtonColorExperimentData = new()
                    {
                        DeviceId = Guid.Parse("ddcc2246-7a00-4f48-9fda-793776fcf360"),
                        ButtonColor = "#00FF00",
                    }
                },
                new()
                {
                    Id = Guid.Parse("1f57e730-8e61-40bf-a790-806528f5b3c5"),
                    DeviceToken = "amazingToken",
                    ButtonColorExperimentData = new()
                    {
                        DeviceId = Guid.Parse("1f57e730-8e61-40bf-a790-806528f5b3c5"),
                        ButtonColor = "#00FF00",
                    }
                },
                new()
                {
                    Id = Guid.Parse("c1cebda5-0d0d-4b5d-8543-68f6db204781"),
                    DeviceToken = "strikingToken",
                    ButtonColorExperimentData = new()
                    {
                        DeviceId = Guid.Parse("c1cebda5-0d0d-4b5d-8543-68f6db204781"),
                        ButtonColor = "#FF0000",
                    }
                },
                new()
                {
                    Id = Guid.Parse("112a2f51-a152-43f0-ab2f-4cc777bcd652"),
                    DeviceToken = "radiantToken",
                    ButtonColorExperimentData = new()
                    {
                        DeviceId = Guid.Parse("112a2f51-a152-43f0-ab2f-4cc777bcd652"),
                        ButtonColor = "#00FF00",
                    }
                }
            };
        }

        public static List<Device> GetDevicesWithPriceExperimentData()
        {
            return new()
            {
                new()
                {
                    Id = Guid.Parse("00c3aef1-c14b-49d9-8656-ed7cb8219912"),
                    DeviceToken = "awesomeToken",
                    PriceExperimentData = new()
                    {
                        DeviceId = Guid.Parse("00c3aef1-c14b-49d9-8656-ed7cb8219912"),
                        Price = 10
                    },
                },
                new()
                {
                    Id = Guid.Parse("ddcc2246-7a00-4f48-9fda-793776fcf360"),
                    DeviceToken = "vibrantToken",
                    PriceExperimentData = new()
                    {
                        DeviceId = Guid.Parse("ddcc2246-7a00-4f48-9fda-793776fcf360"),
                        Price = 20
                    },
                },
                new()
                {
                    Id = Guid.Parse("1f57e730-8e61-40bf-a790-806528f5b3c5"),
                    DeviceToken = "amazingToken",
                    PriceExperimentData = new()
                    {
                        DeviceId = Guid.Parse("1f57e730-8e61-40bf-a790-806528f5b3c5"),
                        Price = 10
                    },
                },
                new()
                {
                    Id = Guid.Parse("c1cebda5-0d0d-4b5d-8543-68f6db204781"),
                    DeviceToken = "strikingToken",
                    PriceExperimentData = new()
                    {
                        DeviceId = Guid.Parse("c1cebda5-0d0d-4b5d-8543-68f6db204781"),
                        Price = 10
                    },
                },
                new()
                {
                    Id = Guid.Parse("112a2f51-a152-43f0-ab2f-4cc777bcd652"),
                    DeviceToken = "radiantToken",
                    PriceExperimentData = new()
                    {
                        DeviceId = Guid.Parse("112a2f51-a152-43f0-ab2f-4cc777bcd652"),
                        Price = 5
                    },
                },
                new()
                {
                    Id = Guid.Parse("74f77ca4-ef46-4e8d-ac21-fe20a1d762de"),
                    DeviceToken = "additionalToken",
                    PriceExperimentData = new()
                    {
                        DeviceId = Guid.Parse("74f77ca4-ef46-4e8d-ac21-fe20a1d762de"),
                        Price = 50
                    },
                }
            };
        }

        public static List<ExperimentDetails> GetExpectedExperimentDetails()
        {
            var allDevices = GetDevicesWithAllData();
            var priceExperimentDevices = allDevices.Where(d => d.PriceExperimentData != null)
                .Select(d => d.PriceExperimentData)
                .GroupBy(ped => ped.Price)
                .Select(o => new ExperimentOptionDevices() { ExperimentOption = o.Key.ToString(), DeviceCount = o.Count() })
                .ToList();
            var buttonExperimentDevices = allDevices.Where(d => d.ButtonColorExperimentData != null)
                .Select(d => d.ButtonColorExperimentData)
                .GroupBy(bcde => bcde.ButtonColor)
                .Select(o => new ExperimentOptionDevices() { ExperimentOption = o.Key, DeviceCount = o.Count() })
                .ToList();

            return new()
            {
                new ExperimentDetails() { ExperimentName = AvailableExperiments.ButtonColor.Name, ExperimentOptionDevices = buttonExperimentDevices, DevicesInExperimentCount = 5 },
                new ExperimentDetails() { ExperimentName = AvailableExperiments.PriceOption.Name, ExperimentOptionDevices = priceExperimentDevices, DevicesInExperimentCount = 6 },
            };
        }
    }
}
