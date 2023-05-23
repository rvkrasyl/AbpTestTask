using AbpBll.Entities.DTOs;
using AbpBll.Exceptions;
using AbpBll.Services;
using AbpDal.Data.Interfaces;
using AbpDal.Entities;
using AbpDal.Entities.EnumClasses;
using AbpTaskTests.AbpBllTests.EqualityComparers;
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

        [Test]
        public async Task GetButtonColorForDeviceAsync_AddsNewColorExperimentDataToDb_WhenThereIsNoExperementForCurrentDevice()
        {
            // Arrange
            string deviceToken = "unexperimented";
            var uowMock = _mocker.GetMock<IUnitOfWork>();
            var noExperimnentDataDevice = _mocker.Get<Device>();

            // Act
            await _mocker.Get<ExperimentService>()
                .GetButtonColorForDeviceAsync(deviceToken);

            // Assert
            uowMock.Verify(_ =>
                _.ButtonColorExperimentRepository.AddAsync(It.Is<ButtonColorExperimentData>(d =>
                    d.DeviceId == noExperimnentDataDevice.Id)),
                Times.Once);
        }

        [TestCase("awesomeToken")]
        [TestCase("amazingToken")]
        [TestCase("strikingToken")]
        public async Task GetButtonColorForDeviceAsync_ReturnsExistedExperimentalData_WhenItAlreadyExistsForCurrentDevice(string deviceToken)
        {
            // Arrange
            var expectedData = UnitTestHelper.GetDevicesWithAllData().First(d => d.DeviceToken == deviceToken);
            var uowMock = _mocker.GetMock<IUnitOfWork>();
            uowMock.Setup(_ => _.DeviceRepository.GetByTokenWithColorExperimentAsync(It.IsIn(deviceToken)))
                .ReturnsAsync(expectedData);
            var expectedResult = new ButtonColorDto() {
                Key = AvailableExperiments.ButtonColor.Name,
                Value = expectedData.ButtonColorExperimentData.ButtonColor
            };
            
            // Act
            var result = await _mocker.Get<ExperimentService>()
                .GetButtonColorForDeviceAsync(deviceToken);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult).Using(new ButtonColorDtoEqualityComparer()));
        }

        [TestCase("awesomeToken")]
        [TestCase("amazingToken")]
        [TestCase("strikingToken")]
        public async Task GetButtonColorForDeviceAsync_DoesntCallsDbForAnyData(string deviceToken)
        {
            // Arrange
            var expectedData = UnitTestHelper.GetDevicesWithAllData().First(d => d.DeviceToken == deviceToken);
            var uowMock = _mocker.GetMock<IUnitOfWork>();
            uowMock.Setup(_ => _.DeviceRepository.GetByTokenWithColorExperimentAsync(It.IsIn(deviceToken)))
                .ReturnsAsync(expectedData);

            // Act
            await _mocker.Get<ExperimentService>()
                .GetButtonColorForDeviceAsync(deviceToken);

            // Assert
            uowMock.Verify(_ =>
                _.DeviceRepository.AddAsync(It.IsAny<Device>()),
                Times.Never);
            uowMock.Verify(_ =>
                _.ButtonColorExperimentRepository.AddAsync(It.IsAny<ButtonColorExperimentData>()),
                Times.Never);
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

        [Test]
        public async Task GetPriceOptionForDeviceAsync_AddsNewPriceExperimentDataToDb_WhenThereIsNoExperimentForCurrentDevice()
        {
            // Arrange
            string deviceToken = "unexperimented";
            var uowMock = _mocker.GetMock<IUnitOfWork>();
            var noExperimnentDataDevice = _mocker.Get<Device>();

            // Act
            await _mocker.Get<ExperimentService>()
                .GetPriceOptionForDeviceAsync(deviceToken);

            // Assert
            uowMock.Verify(_ =>
                _.PriceExperimentRepository.AddAsync(It.Is<PriceExperimentData>(d =>
                    d.DeviceId == noExperimnentDataDevice.Id)),
                Times.Once);
        }

        [TestCase("additionalToken")]
        [TestCase("vibrantToken")]
        [TestCase("radiantToken")]
        public async Task GetPriceOptionForDeviceAsync_ReturnsExistedExperimentalData_WhenItAlreadyExistsForCurrentDevice(string deviceToken)
        {
            // Arrange
            var expectedData = UnitTestHelper.GetDevicesWithAllData().First(d => d.DeviceToken == deviceToken);
            var uowMock = _mocker.GetMock<IUnitOfWork>();
            uowMock.Setup(_ => _.DeviceRepository.GetByTokenWithPriceExperimentAsync(It.IsIn(deviceToken)))
                .ReturnsAsync(expectedData);
            var expectedResult = new PriceOptionDto()
            {
                Key = AvailableExperiments.PriceOption.Name,
                Value = expectedData.PriceExperimentData.Price
            };

            // Act
            var result = await _mocker.Get<ExperimentService>()
                .GetPriceOptionForDeviceAsync(deviceToken);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult).Using(new PriceOptionDtoEqualityComparer()));
        }

        [TestCase("radiantToken")]
        [TestCase("additionalToken")]
        [TestCase("vibrantToken")]
        public async Task GetPriceOptionForDeviceAsync_DoesntCallsDbForAnyData(string deviceToken)
        {
            // Arrange
            var expectedData = UnitTestHelper.GetDevicesWithAllData().First(d => d.DeviceToken == deviceToken);
            var uowMock = _mocker.GetMock<IUnitOfWork>();
            uowMock.Setup(_ => _.DeviceRepository.GetByTokenWithPriceExperimentAsync(It.IsIn(deviceToken)))
                .ReturnsAsync(expectedData);

            // Act
            await _mocker.Get<ExperimentService>()
                .GetPriceOptionForDeviceAsync(deviceToken);

            // Assert
            uowMock.Verify(_ =>
                _.DeviceRepository.AddAsync(It.IsAny<Device>()),
                Times.Never);
            uowMock.Verify(_ =>
                _.PriceExperimentRepository.AddAsync(It.IsAny<PriceExperimentData>()),
                Times.Never);
        }

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();
            var noExperimnentDataDevice = new Device() { Id = Guid.Parse("c21d444c-3af7-442d-a909-180af04c5a49") };

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(_ => _.DeviceRepository.GetByTokenWithColorExperimentAsync(It.IsIn("unexisted")))
                .ReturnsAsync((Device)default);
            uowMock.Setup(_ => _.DeviceRepository.GetByTokenWithPriceExperimentAsync(It.IsIn("unexisted")))
                .ReturnsAsync((Device)default);
            uowMock.Setup(_ => _.DeviceRepository.GetByTokenWithColorExperimentAsync(It.IsIn("unexperimented")))
                .ReturnsAsync(noExperimnentDataDevice);
            uowMock.Setup(_ => _.DeviceRepository.GetByTokenWithPriceExperimentAsync(It.IsIn("unexperimented")))
                .ReturnsAsync(noExperimnentDataDevice);
            uowMock.Setup(_ => _.DeviceRepository.AddAsync(It.IsAny<Device>()));
            uowMock.Setup(_ => _.ButtonColorExperimentRepository.AddAsync(It.IsAny<ButtonColorExperimentData>()));
            uowMock.Setup(_ => _.PriceExperimentRepository.AddAsync(It.IsAny<PriceExperimentData>()));

            var experimentService = new ExperimentService(uowMock.Object);

            _mocker.Use(uowMock);
            _mocker.Use(experimentService);
            _mocker.Use(noExperimnentDataDevice);
        }
    }
}
