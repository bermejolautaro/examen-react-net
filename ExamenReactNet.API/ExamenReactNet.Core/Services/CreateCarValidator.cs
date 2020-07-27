using ExamenReactNet.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenReactNet.Core.Services
{
    class CreateCarValidator : AbstractValidator<Car>
    {
        public CreateCarValidator()
        {
            RuleFor(c => c.Doors).GreaterThan(0);
            RuleFor(c => c.Model).NotEmpty();
            RuleFor(c => c.LicensePlate)
                .Length(8)
                .Matches(@"^[a-zA-Z0-9]+$");
            RuleFor(c => c.Owner).EmailAddress();
            RuleFor(c => c.BrandId).GreaterThan(0);
        }
    }
}
