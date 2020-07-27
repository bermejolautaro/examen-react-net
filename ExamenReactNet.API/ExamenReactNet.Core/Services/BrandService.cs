using ExamenReactNet.Core.Models;
using ExamenReactNet.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamenReactNet.Core.Services
{
    public class BrandService : IBrandService
    {
        private readonly IRepository<Brand> _repository;

        public BrandService(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Brand>> GetAllBrandsAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
