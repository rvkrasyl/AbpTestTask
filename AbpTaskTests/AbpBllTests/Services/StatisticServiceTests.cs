using AbpDal.Data;
using AbpDal.Entities;
using AbpDal.Repositories;
using AutoBogus;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
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
        public async Task GetAllPagedAndFilteredGames_Pagination_Success()
        {
            // Arrange
            var devices = _mocker.Get<List<Device>>();
            var expectedDevice = devices[1];
            var repository = _mocker.CreateInstance<DeviceRepository>();

            // Act
            var result = await repository.GetByTokenWithColorExperimentAsync(expectedDevice.DeviceToken);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(expectedDevice));
            });

            [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();

            var optionBuilderMock = new DbContextOptionsBuilder<AbpExperimentDbContext>();
            var dbContextMock = new Mock<AbpExperimentDbContext>(optionBuilderMock.Options);

            var devices = new AutoFaker<Device>()
                .RuleFor(d => d.ButtonColorExperimentData, f => new AutoFaker<ButtonColorExperimentData>())
                .RuleFor(d => d.PriceExperimentData, f => null)
                .Generate(5);

            var devicesDbSetMock = devices.AsQueryable().BuildMockDbSet();

            dbContextMock.Setup(dbContext => dbContext.Set<Device>())
                .Returns(devicesDbSetMock.Object);

            _mocker.Use(devices);
            _mocker.Use(devicesDbSetMock.Object);
            _mocker.Use(dbContextMock.Object);
        }
    }
}
