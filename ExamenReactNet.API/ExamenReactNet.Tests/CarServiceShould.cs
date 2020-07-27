using ExamenReactNet.Core.Models;
using ExamenReactNet.Core.Repositories;
using ExamenReactNet.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace ExamenReactNet.Tests
{
    [TestClass]
    public class CarServiceShould
    {
        private readonly Mock<IRepository<Car>> _carRepositoryMock;
        private readonly ICarService _carService;

        public CarServiceShould()
        {
            _carRepositoryMock = new Mock<IRepository<Car>>();
            _carService = new CarService(_carRepositoryMock.Object);
        }

        [TestMethod]
        public async Task Create_Car_Sucessfully_When_Is_Valid()
        {
            var newCar = new Car()
            {
                BrandId = 1,
                Doors = 2,
                Id = 0,
                LicensePlate = "FF00FF00",
                Model = "A description",
                Owner = "test@mail.com"
            };

            var result = await _carService.CreateCarAsync(newCar);

            Assert.IsTrue(result.IsSuccessful, string.Join(", ", result.Errors));
        }

        [TestMethod]
        public async Task Not_Create_Car_When_BrandId_Is_Less_Than_1()
        {
            var newCar = new Car()
            {
                BrandId = 0,
                Doors = 2,
                Id = 0,
                LicensePlate = "FF00FF00",
                Model = "A description",
                Owner = "test@mail.com"
            };

            var result = await _carService.CreateCarAsync(newCar);

            Assert.IsFalse(result.IsSuccessful, string.Join(", ", result.Errors));
        }

        [TestMethod]
        public async Task Not_Create_Car_When_Doors_Is_Less_Than_1()
        {
            var newCar = new Car()
            {
                BrandId = 0,
                Doors = 0,
                Id = 0,
                LicensePlate = "FF00FF00",
                Model = "A description",
                Owner = "test@mail.com"
            };

            var result = await _carService.CreateCarAsync(newCar);

            Assert.IsFalse(result.IsSuccessful, string.Join(", ", result.Errors));
        }

        [TestMethod]
        public async Task Not_Create_Car_When_License_Plate_Length_Is_Not_Exactly_8()
        {
            var newCar = new Car()
            {
                BrandId = 1,
                Doors = 1,
                Id = 0,
                LicensePlate = "FF00",
                Model = "A description",
                Owner = "test@mail.com"
            };

            var result = await _carService.CreateCarAsync(newCar);

            Assert.IsFalse(result.IsSuccessful, string.Join(", ", result.Errors));
        }

        [TestMethod]
        public async Task Not_Create_Car_When_License_Plate_Contains_Not_Alphanumeric_Characters()
        {
            var newCar = new Car()
            {
                BrandId = 1,
                Doors = 1,
                Id = 0,
                LicensePlate = "FF00!${}",
                Model = "A description",
                Owner = "test@mail.com"
            };

            var result = await _carService.CreateCarAsync(newCar);

            Assert.IsFalse(result.IsSuccessful, string.Join(", ", result.Errors));
        }

        [TestMethod]
        public async Task Not_Create_Car_When_Model_Is_Empty_Or_Whitespace()
        {
            var newCar = new Car()
            {
                BrandId = 1,
                Doors = 1,
                Id = 0,
                LicensePlate = "FF00!${}",
                Model = "",
                Owner = "test@mail.com"
            };

            var result = await _carService.CreateCarAsync(newCar);

            Assert.IsFalse(result.IsSuccessful, string.Join(", ", result.Errors));
        }

        [TestMethod]
        public async Task Not_Create_Car_When_Owner_Is_Not_An_Email()
        {
            var newCar = new Car()
            {
                BrandId = 1,
                Doors = 1,
                Id = 0,
                LicensePlate = "FF00!${}",
                Model = "",
                Owner = "owner"
            };

            var result = await _carService.CreateCarAsync(newCar);

            Assert.IsFalse(result.IsSuccessful, string.Join(", ", result.Errors));
        }
    }
}
