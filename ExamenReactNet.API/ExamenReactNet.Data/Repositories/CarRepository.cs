using ExamenReactNet.Core.Models;
using ExamenReactNet.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamenReactNet.Data.Repositories
{
    public class CarRepository : Repository<Car>, IRepository<Car>
    {
        public CarRepository(DbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _context.Set<Car>().Include(c => c.Brand).ToListAsync();
        }
    }
}
