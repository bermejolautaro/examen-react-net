using ExamenReactNet.Core.Models;
using ExamenReactNet.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Result<Car>> CreateCarAsync(Car newCar)
        {
            var validationResult = await new CreateCarValidator().ValidateAsync(newCar);

            if (!validationResult.IsValid)
                return Result<Car>.Error(validationResult.Errors.Select(x => x.ErrorMessage));

            await _repository.AddAsync(newCar);
            await _repository.CommitAsync();

            return Result<Car>.Ok(newCar);
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
