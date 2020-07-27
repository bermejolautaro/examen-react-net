using ExamenReactNet.Api.DataTransferObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenReactNet.Api.Validators
{
    public class CarToCreateDtoValidator : AbstractValidator<CarToCreateDto>
    {
        public CarToCreateDtoValidator()
        {
            RuleFor(c => c.Doors).GreaterThan(0);
            RuleFor(c => c.Model).NotEmpty();
            RuleFor(c => c.LicensePlate).Length(8);
            RuleFor(c => c.Owner).EmailAddress();
            RuleFor(c => c.BrandId).GreaterThan(0);
        }
    }
}
