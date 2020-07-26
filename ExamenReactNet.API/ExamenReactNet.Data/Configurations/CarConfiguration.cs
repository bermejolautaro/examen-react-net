using ExamenReactNet.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ExamenReactNet.Data.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).UseIdentityColumn();

            builder.Property(c => c.LicensePlate)
                   .IsRequired()
                   .HasMaxLength(8);

            builder.Property(c => c.Model).IsRequired();

            builder.Property(c => c.Doors).IsRequired();

            builder.Property(c => c.Owner).IsRequired();

            builder.HasOne(c => c.Brand)
                   .WithMany();

            builder.ToTable("Cars");
        }
    }
}
