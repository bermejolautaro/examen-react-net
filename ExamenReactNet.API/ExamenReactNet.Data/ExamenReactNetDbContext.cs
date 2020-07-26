using ExamenReactNet.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenReactNet.Data
{
    public class ExamenReactNetDbContext : DbContext
    {
        public ExamenReactNetDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new BrandConfiguration());
        }
    }
}
