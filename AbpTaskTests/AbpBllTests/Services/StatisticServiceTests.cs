using AbpBll.Services;
using AbpDal.Data.Interfaces;
using AbpDal.Repositories.Interfaces;
using AbpTaskTests.AbpBllTests.EqualityComparers;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace AbpTaskTests.AbpBllTests.Services
{
    [TestFixture]
    public class StatisticServiceTests
    {
        private AutoMocker _mocker;

        [Test]
        public async Task GetStatisticAsync_ReturnsCorrectModel()
        {
            // Arrange
            var expectedResult = UnitTestHelper.GetExpectedExperimentDetails();

            // Act
            var result = await _mocker.Get<StatisticService>()
                .GetStatisticAsync();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Is.EqualTo(expectedResult).Using(new ExperimentDetailsEqualityComparer()));
            });
        }

        [Test]
        public async Task GetStatisticAsync_CallsForDevicesWithExperimentData()
        {
            // Arrange
            var repositoryMock = _mocker.GetMock<IDeviceRepository>();
            var repository = _mocker.Get<IDeviceRepository>();

            // Act
            await repository.GetAllWithExperimentsDataAsync();

            // Assert
            repositoryMock.Verify(_ => _.GetAllWithExperimentsDataAsync(), Times.Once);
        }

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(_ => _.DeviceRepository.GetAllWithExperimentsDataAsync())
                .ReturnsAsync(UnitTestHelper.GetDevicesWithAllData());

            var statisticService = new StatisticService(uowMock.Object);

            _mocker.Use(uowMock);
            _mocker.Use(statisticService);
        }
    }
}
