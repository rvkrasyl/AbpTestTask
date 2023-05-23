using AbpBll.Exceptions;
using AbpBll.Services;
using AbpDal.Data.Interfaces;
using AbpDal.Entities;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace AbpTaskTests.AbpBllTests.Services
{
    [TestFixture]
    public class ExperimentServiceTests
    {
        private AutoMocker _mocker;

        [TestCase("")]
        [TestCase("   ")]
        [TestCase(null)]
        [TestCase("asd1")]
        public void GetButtonColorForDeviceAsync_ThrowsException_WhenInputTokenIsInvalid(string token)
        {
            // Act + Assert
            Assert.ThrowsAsync<UserInputException>(() => _mocker.Get<ExperimentService>()
                .GetButtonColorForDeviceAsync(token));
        }

        [Test]
        public async Task GetButtonColorForDeviceAsync_AddsNewDeviceToDb_WhenThereIsSuchDeviceInDb()
        {
            // Arrange
            string deviceToken = "unexisted";
            var uowMock = _mocker.GetMock<IUnitOfWork>();

            // Act
            await _mocker.Get<ExperimentService>()
                .GetButtonColorForDeviceAsync(deviceToken);

            // Assert
            uowMock.Verify(_ =>
                _.DeviceRepository.AddAsync(It.Is<Device>(d => d.DeviceToken == deviceToken)),
                Times.Once);
        }

        [TestCase("")]
        [TestCase("   ")]
        [TestCase(null)]
        [TestCase("asd1")]
        public void GetPriceOptionForDeviceAsync_ThrowsException_WhenInputTokenIsInvalid(string token)
        {
            // Act + Assert
            Assert.ThrowsAsync<UserInputException>(() => _mocker.Get<ExperimentService>()
                .GetPriceOptionForDeviceAsync(token));
        }

        [Test]
        public async Task GetPriceOptionForDeviceAsync_AddsNewDeviceToDb_WhenThereIsSuchDeviceInDb()
        {
            // Arrange
            string deviceToken = "unexisted";
            var uowMock = _mocker.GetMock<IUnitOfWork>();

            // Act
            await _mocker.Get<ExperimentService>()
                .GetPriceOptionForDeviceAsync(deviceToken);

            // Assert
            uowMock.Verify(_ =>
                _.DeviceRepository.AddAsync(It.Is<Device>(d => d.DeviceToken == deviceToken)),
                Times.Once);
        }

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(_ => _.DeviceRepository.GetByTokenWithColorExperimentAsync(It.IsIn("unexisted")))
                .ReturnsAsync((Device)default);
            uowMock.Setup(_ => _.DeviceRepository.GetByTokenWithPriceExperimentAsync(It.IsIn("unexisted")))
                .ReturnsAsync((Device)default);
            uowMock.Setup(_ => _.DeviceRepository.AddAsync(It.IsAny<Device>()));
            uowMock.Setup(_ => _.ButtonColorExperimentRepository.AddAsync(It.IsAny<ButtonColorExperimentData>()));
            uowMock.Setup(_ => _.PriceExperimentRepository.AddAsync(It.IsAny<PriceExperimentData>()));

            var experimentService = new ExperimentService(uowMock.Object);

            _mocker.Use(uowMock);
            _mocker.Use(experimentService);
        }
    }
}
