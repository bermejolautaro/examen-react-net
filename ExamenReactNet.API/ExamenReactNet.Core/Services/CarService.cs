using ExamenReactNet.Core.Models;
using ExamenReactNet.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamenReactNet.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> _repository;

        public CarService(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<Car> CreateCarAsync(Car newCar)
        {
            await _repository.AddAsync(newCar);
            await _repository.CommitAsync();
            return newCar;
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
